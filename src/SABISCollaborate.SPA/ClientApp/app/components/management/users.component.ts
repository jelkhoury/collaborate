import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'manage-users',
    templateUrl: './users.component.html'
})

export class ManageUsersComponent {
    public users: User[];

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        http.get(originUrl + '/api/management/users').subscribe(result => {
            this.users = result.json() as User[];
            console.log(this.users);
        });
    }
}


interface User {
    username: string;
}