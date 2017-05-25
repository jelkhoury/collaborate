import { Component } from '@angular/core';
import { UsersService, User } from '../../services/users.service';
import { Gender } from '../../shared/shared';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    providers: [UsersService]
})

export class RegistrationComponent {
    public model: RegistrationModel;
    private _usersService: UsersService;

    constructor(usersService: UsersService) {
        this._usersService = usersService;
        this.model = new RegistrationModel();
    }
}

class RegistrationModel {
    username: string;
    password: string;
    confirmPassowrd: string;
    email: string;
    firstName: string;
    middleName: string;
    lastName: string;
    gender: Gender;
}