import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { ChatService } from '../../services/chat.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private authService: AuthenticationService, private chatService: ChatService) {
        this.authService.userLoggedIn$.subscribe(u => {
            this.chatService.start();
        });

        this.authService.userLoggedOut$.subscribe(() => {
            this.chatService.stop();
        });
    }
}
