import { Component, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { NgForm, FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';
import { Gender, MaritalStatus, Position, Department } from '../../shared/models';
import { DropdownOption, DropdownComponent } from '../../shared/components/dropdown.component';
import { MultiDropdownOption, MultiDropdownComponent } from '../../shared/components/multi-dropdown.component';
import { UploadOutput, UploadInput, UploadFile } from 'ngx-uploader';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    providers: [RegistrationService, FormBuilder]
})

export class RegistrationComponent {
    public model: RegistrationModel; // binding model
    public formErrors = {
        username: '',
        password: '',
        confirmPassword: '',
        email: '',
        nickname: '',
        firstName: '',
        lastName: ''
    };

    private isSubmitted = false;
    private currentForm: NgForm;
    @ViewChild('f') newForm: NgForm;
    private initModel: InitRegistrationModel;
    private registrationService: RegistrationService;
    uploadInput: EventEmitter<UploadInput> = new EventEmitter<UploadInput>()
    file: UploadFile;

    constructor(registrationService: RegistrationService, private formBuilder: FormBuilder) {
        this.registrationService = registrationService;
        this.loadModel();
    }

    loadModel() {
        this.model = new RegistrationModel();
        this.registrationService.getInitRegistrationModel().subscribe(m => {
            this.initModel = m.json() as InitRegistrationModel;

            // create departments options
            this.model.departmentsOptions = new Array<MultiDropdownOption>();
            this.initModel.departments.forEach(d => {
                this.model.departmentsOptions.push({
                    id: d.id,
                    name: d.title
                });
            });

            // create positions options
            this.model.positionsOptions = new Array<DropdownOption>();
            this.initModel.positions.forEach(p => {
                this.model.positionsOptions.push({
                    id: p.id,
                    name: p.title
                });
            });
        });
    }
    // when view value changes
    ngAfterViewChecked() {
        if (this.currentForm === this.newForm) { return; }
        this.currentForm = this.newForm;

        if (this.currentForm) {
            this.currentForm.valueChanges.subscribe(data => this.onValueChanged(data));
        }
    }
    // when form value changes
    onValueChanged(data?: any) {
        if (!this.currentForm) { return; }
        const form = this.currentForm.form;

        for (const field in this.formErrors) {
            this.formErrors[field] = '';
            const control = form.get(field);

            if (control && (control.dirty || control.touched || this.isSubmitted)) {
                if (!control.valid) {
                    this.formErrors[field] = this.getValidationMessage(field);
                }

                if ((field == 'password' || field == 'confirmPassword') && this.model.password != this.model.confirmPassword) {
                    this.formErrors.confirmPassword = 'Confirm password should match the password';
                }
            }
        }
    }
    // get validation message by field name
    getValidationMessage(field: string): string {
        if (field == 'username') {
            return 'Username is required';
        }
        else if (field == 'password') {
            return 'Password is required and should match the Confirm Password';
        }
        else if (field == 'confirmPassword') {
            return 'Confirm Password is required and should match the Password';
        }
        else if (field == 'email') {
            return 'Email is required';
        }
        else if (field == 'nickname') {
            return 'A Nickname is required';
        }
        else if (field == 'firstName') {
            return 'First Name is required';
        }
        else if (field == 'lastName') {
            return 'Last Name is required';
        }
    }
    // upload temp profile picture to the server
    uploadTempPicture(): void {  // manually start uploading
        const event: UploadInput = {
            type: 'uploadAll',
            url: 'http://localhost:1529/api/management/profile/picture/temp',
            method: 'POST',
            //data: { foo: 'bar' },
            concurrency: 1 // set sequential uploading of files with concurrency 1
        }
        setTimeout(() => {
            this.uploadInput.emit(event);
        }, 0);
    }
    // receive upload events from the upload control
    onUploadOutput(output: UploadOutput): void {
        if (output.type === 'done') {
            this.file = output.file;

            // set view url
            this.model.profilePictureUrl = "http://localhost:1529/api/management/profile/picture/temp?fileId=" + this.file.response;
        }
    }
    // register click
    onRegister(): void {
        this.isSubmitted = true;
        // call for validation
        this.onValueChanged();
        if (this.currentForm.valid) {
            var user = this.model;

            var tempPictureId = this.file != null ? this.file.response : "";
            // register the user and redirect to all users
            this.registrationService.register(user.username, user.password, user.email, user.nickname, user.firstName, user.lastName, user.maritalStatus, user.gender, user.birthDate, user.departmentIds, user.positionId, user.employmentDate, tempPictureId)
                .subscribe(r => {
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
    // validate the username is available
    validateUsernameAvailable(): void {
        this.model.isUsernameAvailable = true;
        if (this.model.username.trim().length > 0) {
            this.model.isValidatingUsername = true;

            this.registrationService.isUsernameAvailable(this.model.username).subscribe(r => {
                var isAvailable: boolean = r.json() as boolean;
                this.model.isUsernameAvailable = isAvailable;
                this.model.isValidatingUsername = false;
            });
        }
    }
}

class RegistrationModel {
    nickname: string;
    username: string;
    password: string;
    confirmPassword: string;
    email: string;
    firstName: string;
    lastName: string;
    maritalStatus: MaritalStatus;
    gender: Gender;
    birthDate: Date;
    positionId: number;
    departmentIds: number[];
    employmentDate: Date;
    departmentsOptions: MultiDropdownOption[];
    positionsOptions: DropdownOption[];
    profilePictureUrl: string;
    isValidatingUsername: boolean;
    isUsernameAvailable: boolean;

    constructor() {
        this.gender = Gender.Male;
        this.maritalStatus = MaritalStatus.Unspecified;
        this.profilePictureUrl = 'img/no-avatar.jpg';
        this.isValidatingUsername = false;
        this.isUsernameAvailable = true;
    }
}

class InitRegistrationModel {
    departments: Department[];
    positions: Position[];
}