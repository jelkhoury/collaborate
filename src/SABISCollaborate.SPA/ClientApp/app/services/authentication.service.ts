import { Inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AuthenticationService {
    // Observable string sources
    private userLoggedInSource = new Subject<string>();
    private userLoggedOutSource = new Subject();

    // Observable string streams
    userLoggedIn$ = this.userLoggedInSource.asObservable();
    userLoggedOut$ = this.userLoggedOutSource.asObservable();

    isAuthenticated(): boolean {
        if (localStorage.getItem('currentUser') && true) {
            return true;
        }
        
        return false;
    }

    getCurrentUser(): string {
        var username = localStorage.getItem('currentUser');

        return username;
    }

    login(username: string, password: string): void {
        if (username == password) {
            localStorage.setItem("currentUser", username);
            this.userLoggedInSource.next(username);
        }
    };

    logout(): void {
        localStorage.removeItem("currentUser");
        this.userLoggedOutSource.next();
    }
}