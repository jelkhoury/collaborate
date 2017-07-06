import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { User } from '../shared/models';
import { UserManager } from 'oidc-client';
import 'rxjs/Rx';

@Injectable()
export class AuthenticationService {
    private userManager: UserManager;

    // Observable string sources
    private userLoggedInSource = new Subject<string>();
    private userLoggedOutSource = new Subject();

    // Observable string streams
    userLoggedIn$ = this.userLoggedInSource.asObservable();
    userLoggedOut$ = this.userLoggedOutSource.asObservable();

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {
        var settings = {
            // URL of your OpenID Connect server.
            // The library uses it to access the metadata document
            authority: 'http://localhost:12279/',

            client_id: 'sabiscollaborate.js',

            popup_redirect_uri: 'http://localhost:56668/popup.html',
            //silent_redirect_uri: 'http://localhost:56668/silent-renew.html',
            //post_logout_redirect_uri: 'http://localhost:56668/index.html',

            // What you expect back from The IdP.
            // In that case, like for all JS-based applications, an identity token
            // and an access token
            response_type: 'id_token',

            // Scopes requested during the authorization request
            scope: 'openid profile',

            //// Number of seconds before the token expires to trigger
            //// the `tokenExpiring` event
            //accessTokenExpiringNotificationTime: 4,

            //// Do we want to renew the access token automatically when it's
            //// about to expire?
            //automaticSilentRenew: true,

            // Do we want to filter OIDC protocal-specific claims from the response?
            filterProtocolClaims: true
        };

        this.userManager = new UserManager(settings);
    }

    isAuthenticated(): boolean {
        this.userManager.signinRedirect();

        return localStorage.getItem('currentUser') && true;
    }

    getCurrentUser(): string {
        var username = localStorage.getItem('currentUser');

        return username;
    }

    login(username: string, password: string): Observable<User> {
        var url = this.originUrl + '/api/management/user';

        return Observable.create(observer => {
            this.http.post(url, { Username: username, Password: password }).map(res => res.json() as User).subscribe(u => {
                if (u) {
                    localStorage.setItem("currentUser", username);
                    this.userLoggedInSource.next(username);
                }

                observer.next(u);
                //call complete if you want to close this stream (like a promise)
                observer.complete();
            });
        });
    };

    logout(): void {
        localStorage.removeItem("currentUser");
        this.userLoggedOutSource.next();
    }
}