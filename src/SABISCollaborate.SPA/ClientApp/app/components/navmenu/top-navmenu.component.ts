import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'top-nav-menu',
    templateUrl: './top-navmenu.component.html',
    styleUrls: ['./top-navmenu.component.css']
})

export class TopNavMenuComponent {
    private model: any;

    constructor(private authService: AuthenticationService, private router: Router) {
        this.refreshModel();

        this.authService.userLoggedIn$.subscribe(u => {
            this.refreshModel();
        });

        this.authService.userLoggedOut$.subscribe(() => {
            this.refreshModel();
        });
    }

    logout() {
        this.authService.logout();
        this.router.navigateByUrl('/login');
    }

    private refreshModel() {
        this.model = {
            username: this.authService.getCurrentUser(),
            isAdmin: this.authService.getCurrentUser() == "admin",
            isLoggedIn: this.authService.isAuthenticated()
        }
    }
}
