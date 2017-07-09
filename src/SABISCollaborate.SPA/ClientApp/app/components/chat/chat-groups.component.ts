import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';
import { ChatGroupSummary, ChatGroupHistory } from '../../shared/models';

// TODO : in the next phase we can cache the received messages when the group is not selected
@Component({
    selector: 'chat-groups',
    templateUrl: './chat-groups.component.html',
    providers: [ChatService]
})
export class ChatGroupsComponent implements OnInit {
    private model: ViewModel = {
        groups: null,
        textMessage: "",
        selectedGroup: undefined
    };

    constructor(private chatService: ChatService) {

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
        // TODO : add to current group or add to unread of other groups
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
        }
    }
}

interface ViewModel {
    groups: ChatGroupSummary[];
    textMessage: string;
    selectedGroup: ChatGroupHistory;
}