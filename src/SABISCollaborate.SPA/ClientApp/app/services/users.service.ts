import { Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UsersService {
    private _url: string;
    private _http: Http;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this._url = originUrl;
        this._http = http;
    }

    getUsers(): Observable<Response> {
        return this._http.get(this._url + '/api/management/users');
    }

    register(username: string, password: string, email: string): Observable<Response> {
        return this._http.post(this._url + '/api/management/registration', {
            Username: username,
            Password: password,
            Email: email
        });
    }
}

export interface User {
    username: string;
}