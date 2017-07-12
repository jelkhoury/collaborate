import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';
import { AuthenticationService } from '../../services/authentication.service';
import { ChatGroupSummary, ChatGroupHistory, ChatGroupTextMessage } from '../../shared/models';

// TODO : in the next phase we can cache the received messages when the group is not selected
@Component({
    selector: 'chat-groups',
    templateUrl: './chat-groups.component.html'
})
export class ChatGroupsComponent implements OnInit {
    private model: ViewModel = {
        groups: null,
        textMessage: "",
        selectedGroup: undefined,
        currentUsername: this.authService.getCurrentUser().profile.preferred_username
    };

    constructor(private chatService: ChatService, private authService: AuthenticationService) {

    }
    ngOnInit() {
        // listen to messages
        this.chatService.messageReceived$.subscribe(m => {
            this.onMessageReceived(m);
        });

        // get groups
        this.chatService.getGroupsWithSummary().subscribe(groups => {
            this.model.groups = groups;
        });
    }

    onMessageReceived(message: any) {
        this.chatService.sendAck(message.DestinationId, message.Id);

        var messageHistory: ChatGroupTextMessage = {
            id: message.Id,
            senderUserId: message.UserId,
            sender: message.Sender,
            text: message.Body,
            isRead: true,
            dateSent: message.ClientSentDate
        }
        this.model.selectedGroup.messages.push(messageHistory);
    }
    selectGroup(groupId: number) {
        this.chatService.getGroupHistory(groupId).subscribe(h => {
            this.model.selectedGroup = h;
        });
    }
    onMessageChanged($event) {
        // 13 === enter
        if ($event.charCode == 13) {
            // TODO : send only when the server has received the previous message (to maintain messages order)
            this.chatService.sendTextMessage(this.model.selectedGroup.id, this.model.textMessage);
            var messageHistory: ChatGroupTextMessage = {
                id: 0,
                sender: "",
                text: this.model.textMessage,
                isRead: true,
                dateSent: new Date()
            }
            this.model.selectedGroup.messages.push(messageHistory);

            this.model.textMessage = "";
        }
        return true;
    }
}

interface ViewModel {
    groups: ChatGroupSummary[];
    textMessage: string;
    selectedGroup: ChatGroupHistory;
    currentUsername: string;
}