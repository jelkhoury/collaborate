import { Component } from '@angular/core';
import { UsersService, User } from '../../services/users.service';

@Component({
    selector: 'manage-users',
    templateUrl: './users.component.html',
    providers: [UsersService]
})

export class ManageUsersComponent {
    public users: User[];
    private _usersService: UsersService;

    constructor(usersService: UsersService) {
        this._usersService = usersService;

        this._usersService.getUsers().subscribe(result => {
            this.users = result.json() as User[];
        });
    }
}