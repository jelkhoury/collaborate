import { Component } from '@angular/core';
import { RegistrationService, User } from '../../services/registration.service';

@Component({
    selector: 'manage-users',
    templateUrl: './users.component.html',
    providers: [RegistrationService]
})

export class ManageUsersComponent {
    public users: User[];
    private _usersService: RegistrationService;

    constructor(usersService: RegistrationService) {
        this._usersService = usersService;

        this._usersService.getUsers().subscribe(result => {
            this.users = result.json() as User[];
            console.log(result.json());
            console.log(this.users);
        });
    }
}