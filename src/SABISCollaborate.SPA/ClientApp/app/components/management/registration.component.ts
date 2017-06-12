import { Component, EventEmitter, ViewChild } from '@angular/core';
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

    //// profile picture uploader
    //uploadInput: EventEmitter<UploadInput>;
    //files: UploadFile[];

    constructor(registrationService: RegistrationService, private formBuilder: FormBuilder) {
        //this.files = []; // local uploading files array
        //this.uploadInput = new EventEmitter<UploadInput>();
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

        //var gp = this.formBuilder.group({
        //    'passwords': this.formBuilder.group({
        //        password: ['', Validators.required],
        //        repeat: ['', Validators.required]
        //    }, { validator: this.areEqual })
        //});
        //this.currentForm.addFormGroup(gp);
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

    //startUpload(): void {  // manually start uploading
    //    const event: UploadInput = {
    //        type: 'uploadAll',
    //        url: 'http://localhost:49506/api/management/profile/picture',
    //        method: 'POST',
    //        //data: { foo: 'bar' },
    //        concurrency: 1 // set sequential uploading of files with concurrency 1
    //    }

    //    this.uploadInput.emit(event);
    //}

    //onUploadOutput(output: UploadOutput): void {
    //    console.log(output);

    //    if (output.type === 'addedToQueue') {
    //        this.files.push(output.file); // add file to array when added
    //    } else if (output.type === 'uploading') {
    //        // update current data in files array for uploading file
    //        const index = this.files.findIndex(file => file.id === output.file.id);
    //        this.files[index] = output.file;
    //    } else if (output.type === 'removed') {
    //        // remove file from array when removed
    //        this.files = this.files.filter((file: UploadFile) => file !== output.file);
    //    }
    //}

    // register click
    onRegister(): void {
        this.isSubmitted = true;
        // call for validation
        this.onValueChanged();
        if (this.currentForm.valid) {

            var user = this.model;

            // validate required

            // validate password

            // check unique username

            // register the user and redirect to all users
            this.registrationService.register(user.username, user.password, user.email, user.nickname, user.firstName, user.lastName, user.maritalStatus, user.gender, user.birthDate, user.departmentIds, user.positionId[0], user.employmentDate)
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
    positionId: number[];
    departmentIds: number[];
    employmentDate: Date;
    departmentsOptions: MultiDropdownOption[];
    positionsOptions: DropdownOption[];

    constructor() {
        this.gender = Gender.Male;
        this.maritalStatus = MaritalStatus.Unspecified;
    }
}

class InitRegistrationModel {
    departments: Department[];
    positions: Position[];
}