import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AuthGuard } from './_guards/auth.guard';

// component
import { AppComponent } from './components/app/app.component'
import { LoginComponent } from './components/login/login.component'
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { TopNavMenuComponent } from './components/navmenu/top-navmenu.component';
import { ManageUsersComponent } from './components/management/users.component';
import { ManagementDepartmentsComponent } from './components/management/departments.component';
import { RegistrationComponent } from './components/management/registration.component';
import { GenderComponent } from './shared/components/gender.component';
import { DropdownComponent } from './shared/components/dropdown.component';
import { DatepickerComponent } from './shared/components/datepicker.component';

// services
import { UsersService } from './services/users.service';
import { LocalizationService } from './services/localization.service';
import { AuthenticationService } from './services/authentication.service';

import { AppRoutingModule } from './app-routing.module';

// 3rd party modules
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { Ng2DatetimePickerModule } from 'ng2-datetime-picker';

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        LoginComponent,
        HomeComponent,
        NavMenuComponent,
        TopNavMenuComponent,
        ManageUsersComponent,
        ManagementDepartmentsComponent,
        RegistrationComponent,
        GenderComponent,
        DropdownComponent,
        DatepickerComponent
    ],
    providers: [
        AuthGuard,
        UsersService,
        LocalizationService,
        AuthenticationService
    ],
    imports: [
        AppRoutingModule,
        FormsModule,
        MultiselectDropdownModule,
        Ng2DatetimePickerModule
    ]
};
