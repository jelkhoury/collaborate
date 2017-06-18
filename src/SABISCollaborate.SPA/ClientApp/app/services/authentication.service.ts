import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { User } from '../shared/models';
import 'rxjs/Rx';

@Injectable()
export class AuthenticationService {
    // Observable string sources
    private userLoggedInSource = new Subject<string>();
    private userLoggedOutSource = new Subject();

    // Observable string streams
    userLoggedIn$ = this.userLoggedInSource.asObservable();
    userLoggedOut$ = this.userLoggedOutSource.asObservable();

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {

    }

    isAuthenticated(): boolean {
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