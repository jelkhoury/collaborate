import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChatService, ConnectionStatus } from '../../services/chat.service';
import { AuthenticationService } from '../../services/authentication.service';
import { ChatGroupSummary, ChatGroupHistory, ChatGroupTextMessage } from '../../shared/models';
import { SimpleNotificationsComponent, NotificationsService } from 'angular2-notifications';

// TODO : in the next phase we can cache the received messages when the group is not selected
@Component({
    selector: 'chat-groups',
    templateUrl: './chat-groups.component.html',
    styleUrls: ['./chat-groups.component.css']
})
export class ChatGroupsComponent implements OnInit {
    private currentUserId: number;
    private model: ViewModel = {
        groupsSummary: null,
        pendingTextMessage: "",
        selectedGroupHistory: undefined,
        connectionStatus: 'Connecting...'
        //currentUsername: this.authService.getCurrentUser().profile.preferred_username
    };
    public options = {
        position: ["bottom", "right"],
        timeOut: 3000,
        lastOnBottom: true
    }
    @ViewChild('messagesList') private messagesList: ElementRef;

    constructor(private chatService: ChatService, private authService: AuthenticationService, private _notificationService: NotificationsService) {
        this._notificationService.success(
            'Some Title',
            'Some Content',
            {
                timeOut: 5000,
                showProgressBar: true,
                pauseOnHover: false,
                clickToClose: false,
                maxLength: 10
            }
        );
    }
    ngOnInit() {
        this.currentUserId = this.authService.getCurrentUserId();

        // listen to messages
        this.chatService.messageReceived$.subscribe(m => {
            this.onMessageReceived(m);
        });

        // get groups summary
        this.chatService.getGroupsSummary().subscribe(groupsSummary => {
            this.model.groupsSummary = groupsSummary;
        });

        // watch connection status
        this.chatService.statusChanged$.subscribe(s => {
            this.model.connectionStatus = ConnectionStatus[s];
            if (s == ConnectionStatus.connected) {
                this.chatService.register();
            }
        });
    }

    onMessageReceived(message: any) {
        var messageHistory: ChatGroupTextMessage = {
            id: message.Id,
            senderUserId: message.UserId,
            sender: message.Sender,
            text: message.Body,
            isRead: true,
            dateSent: message.ClientSentDate,
            isFromMe: (message.senderUserId == this.currentUserId)
        }
        this.model.selectedGroupHistory.messages.push(messageHistory);
        this.chatService.setMessageAsRead(message.Id);
        this.scrollToEnd();
        this.displayBrowserNotification(messageHistory.sender, messageHistory.text);
    }
    selectGroup(groupId: number) {
        this.chatService.getGroupHistory(groupId).subscribe(h => {
            h.messages.forEach(m => m.isFromMe = (m.senderUserId == this.currentUserId));
            this.model.selectedGroupHistory = h;
            // set unread messages as read
            var messagesIds: number[] = new Array();
            h.messages.forEach(m => {
                if (m.isRead == false) {
                    messagesIds.push(m.id);
                }
            });
            this.chatService.setMessagesAsRead(messagesIds);
            // scroll the window to the end
            this.scrollToEnd();
        });
    }
    onMessageChanged($event) {
        // 13 === enter
        if ($event.charCode == 13) {
            // TODO : send only when the server has received the previous message (to maintain messages order)
            this.chatService.sendTextMessage(this.model.selectedGroupHistory.id, this.model.pendingTextMessage);
            var messageHistory: ChatGroupTextMessage = {
                id: 0,
                sender: '',
                text: this.model.pendingTextMessage,
                isRead: true,
                dateSent: new Date(),
                isFromMe: true
            }
            this.model.selectedGroupHistory.messages.push(messageHistory);

            this.model.pendingTextMessage = "";
            this.scrollToEnd();
        }
        return true;
    }
    scrollToEnd() {
        setTimeout(() => {
            this.messagesList.nativeElement.scrollTop = this.messagesList.nativeElement.scrollHeight;
        });
    }
    displayBrowserNotification(title: string, body: string): boolean {
        if (!("Notification" in window)) {
            return false;
        }
        Notification.requestPermission(function (permission: NotificationPermission) {
            if (permission === "granted") {
                var notification = new Notification(title, { body: body, icon: "/img/user-avatar.jpg" });
                return true;
            }
        });

        return false;
    }
}

interface ViewModel {
    groupsSummary: ChatGroupSummary[];
    pendingTextMessage: string;
    selectedGroupHistory: ChatGroupHistory;
    connectionStatus: string;
}