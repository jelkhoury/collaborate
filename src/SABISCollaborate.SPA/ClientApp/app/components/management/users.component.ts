import { Component, Pipe, PipeTransform } from '@angular/core';
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


@Pipe({
    name: 'usersPipe'
})

export class usersPipe implements PipeTransform {
    private searchValue: String;
    transform(users: User[], searchValue: string) {
        if (searchValue) {
            searchValue = searchValue.toLowerCase();
            return users.filter(user => (user.username.toLowerCase().indexOf(searchValue) !== -1
                || user.profile.firstName.toLowerCase().indexOf(searchValue) !== -1
                || user.profile.lastName.toLowerCase().indexOf(searchValue) !== -1));
                
            
        } else {
            return users;
        }
    }
}

