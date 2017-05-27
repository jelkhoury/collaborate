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

    onRegister(user: RegistrationModel): void {
        // validate required

        // validate password

        // check unique username

        // register the user and redirect to all users
        this._usersService.register(user.username, user.password, user.email).subscribe(r => {
            alert('Account registered successfully');
        }, e => {
            if (e._body == "9000000") {
                alert('Username/Email already exists');
            }
            else {
                alert('Registration error');
            }
        });
    }
}

class RegistrationModel {
    username: string;
    password: string;
    confirmPassowrd: string;
    email: string;
    firstName: string;
    lastName: string;
    gender: Gender;

    constructor() {
        this.gender = Gender.Male;
    }
}