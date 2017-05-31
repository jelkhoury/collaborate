import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService]
})
export class AppComponent {
    public isAdmin: boolean;

    constructor(private authService: AuthenticationService, private router: Router) {
        this.authService.userLoggedIn$.subscribe(u => {
            this.isAdmin = this.getIsAdmin();
            console.log('this.isAdmin : ' + this.isAdmin);
        });

        this.authService.userLoggedOut$.subscribe(() => {
            this.isAdmin = false;
            this.router.navigateByUrl('/login');
            console.log('this.isAdmin : ' + this.isAdmin);
        });

        this.isAdmin = this.getIsAdmin();
    }

    private getIsAdmin(): boolean {
        return this.authService.getCurrentUser() == "admin";
    }

    logout() {
        this.authService.logout();
    }
}
