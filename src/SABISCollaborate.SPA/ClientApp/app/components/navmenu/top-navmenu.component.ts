import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'top-nav-menu',
    templateUrl: './top-navmenu.component.html',
    styleUrls: ['./top-navmenu.component.css']
})

export class TopNavMenuComponent {
    public model: ViewModel;

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
        //this.router.navigateByUrl('/login');
    }
    globalSearch(): void {
        this.router.navigateByUrl("/search?key=" + this.model.searchText);
    }
    private refreshModel() {
        this.model = {
            username: this.authService.getName(),
            isAdmin: this.authService.getCurrentUser() != null,
            searchText: ""
        }
    }
}

class ViewModel {
    isAdmin: boolean;
    username: string;
    searchText: string;
}