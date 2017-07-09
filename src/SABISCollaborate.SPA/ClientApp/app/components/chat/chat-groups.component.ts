import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';
import { ChatGroupSummary, ChatGroupHistory } from '../../shared/models';

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
        // get groups
        this.chatService.getGroupsWithSummary().subscribe(groups => {
            this.model.groups = groups;
        });
    }

    selectGroup(groupId: number) {
        this.chatService.getGroupHistory(groupId).subscribe(h => {
            this.model.selectedGroup = h;
        });
    }
    onMessageChanged($event) {
        // 13 === enter
        if ($event.charCode == 13) {

        }
    }
}

interface ViewModel {
    groups: ChatGroupSummary[];
    textMessage: string;
    selectedGroup: ChatGroupHistory;
}