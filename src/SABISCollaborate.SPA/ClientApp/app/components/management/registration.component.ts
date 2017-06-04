import { Component } from '@angular/core';
import { UsersService, Department } from '../../services/users.service';
import { Gender } from '../../shared/shared';
import { DropdownOption, DropdownComponent } from '../../shared/components/dropdown.component';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    providers: [UsersService]
})

export class RegistrationComponent {
    public model: RegisterUserModel;

    private initModel: RegistrationModel;
    private usersService: UsersService;
    private departmentsOptions: DropdownOption[];

    constructor(usersService: UsersService) {
        this.usersService = usersService;
        this.loadModel();
    }

    loadModel() {
        this.model = new RegisterUserModel();
        this.usersService.getRegistrationModel().subscribe(m => {
            this.initModel = m.json() as RegistrationModel;
            this.initModel.departments.forEach(d => {
                this.departmentsOptions = new Array<DropdownOption>();

                this.departmentsOptions.push({
                    id: d.id,
                    name: d.title
                });
            });
        });
    }

    // register click
    onRegister(user: RegisterUserModel): void {
        // validate required

        // validate password

        // check unique username

        // register the user and redirect to all users
        this.usersService.register(user.username, user.password, user.email, user.firstName, user.lastName, user.gender, new Date()).subscribe(r => {
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

class RegisterUserModel {
    username: string;
    password: string;
    confirmPassowrd: string;
    email: string;
    firstName: string;
    lastName: string;
    gender: Gender;
    selectedDepartmentIds: number[];

    constructor() {
        this.gender = Gender.Male;
    }
}

class RegistrationModel {
    departments: Department[];
}