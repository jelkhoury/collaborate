import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    public model: any;

    constructor(private router : Router, private authService: AuthenticationService) {
        this.model = {};
    }

    login(): void {
        this.authService.login(this.model.username, this.model.password);

        this.router.navigateByUrl('/home');
    }
}