import { Component, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class LoginComponent {
    model: any;
    isLoading: boolean;
    formErrors = {
        username: '',
        password: ''
    };
    currentForm: NgForm;
    @ViewChild('f') newForm: NgForm;

    constructor(private router: Router, private authService: AuthenticationService) {
        this.model = {};
    }

    login(): void {
        this.onValueChanged();
        if (this.currentForm.valid) {
            this.isLoading = true;

            if (this.authService.login(this.model.username, this.model.password)) {
                this.router.navigateByUrl('/home');
            }
            this.isLoading = false;
        }
    }

    // when form value changes
    onValueChanged(data?: any) {
        if (!this.currentForm) { return; }
        const form = this.currentForm.form;

        for (const field in this.formErrors) {
            this.formErrors[field] = '';
            const control = form.get(field);

            if (control && (control.dirty || control.touched || this.currentForm.submitted) && !control.valid) {
                this.formErrors[field] = this.getValdationMessage(field);
            }
        }
    }

    getValdationMessage(field: string): string {
        if (field == 'username') {
            return 'Username is required';
        }
        else {
            return 'Password is required';
        }
    }

    // when view value changes
    ngAfterViewChecked() {
        this.formChanged();
    }

    // watch the new form
    formChanged() {
        if (this.currentForm === this.newForm) { return; }
        this.currentForm = this.newForm;
        if (this.currentForm) {
            this.currentForm.valueChanges.subscribe(data => this.onValueChanged(data));
        }
    }
}