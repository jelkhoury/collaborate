import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService]
})
export class AppComponent {
    public isAdmin: boolean;

    constructor(private authService: AuthenticationService) {
        this.authService.userLoggedIn$.subscribe(u => {
            this.isAdmin = this.getIsAdmin();
        });

        this.authService.userLoggedOut$.subscribe(() => {
            this.isAdmin = false;
        });

        this.isAdmin = this.getIsAdmin();
    }

    private getIsAdmin(): boolean {
        return this.authService.getCurrentUser() == "admin";
    }
}
