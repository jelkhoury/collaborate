import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { UserManager } from 'oidc-client';

@Injectable()
export class AuthenticationService {
    private isLoggedIn: boolean = false;
    private userManager: UserManager;
    private user: Oidc.User;

    // Observable sources
    private userLoggedInSource = new Subject<string>();
    private userLoggedOutSource = new Subject();
    // Observable streams
    userLoggedIn$ = this.userLoggedInSource.asObservable();
    userLoggedOut$ = this.userLoggedOutSource.asObservable();

    constructor(private router: Router, @Inject('ORIGIN_URL') private originUrl: string) {
        var config = {
            authority: "http://localhost:5557",
            client_id: "sc.js",
            redirect_uri: "http://localhost:5555/signin-callback",
            response_type: "id_token token",
            scope: "openid profile scapi",
            //post_logout_redirect_uri: "http://localhost:5553/index.html",
        };

        this.userManager = new UserManager(config);
    }

    isAuthenticated(): boolean {
        // request login if not loggedin
        if (!this.isLoggedIn) {
            this.login();
        }

        return this.isLoggedIn;
    }
    continueSignin() {
        var current = this;

        this.userManager.signinRedirectCallback().then(function () {
            current.userManager.getUser().then(function (user) {
                current.user = user;
                current.isLoggedIn = true;
                current.userLoggedInSource.next();
                // move to app
                current.router.navigateByUrl('home');
            });
        }).catch(function (e) {
            console.error(e);
        });
    }
    login() {
        this.userManager.signinRedirect();
    }
    logout(): void {
        this.userManager.signoutRedirect();
        this.userLoggedOutSource.next();
    }
    getCurrentUser(): Oidc.User {
        return this.user;
    }
    getName(): string {
        return this.user && this.user.profile ? this.user.profile.name : "";
    }
    getAccessToken(): string {
        return this.user.access_token;
    }
}