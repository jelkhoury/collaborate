import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
import { MaritalStatusComponent } from './shared/components/marital-status.component';
import { DropdownComponent } from './shared/components/dropdown.component';
import { MultiDropdownComponent } from './shared/components/multi-dropdown.component';
import { DatepickerComponent } from './shared/components/datepicker.component';
import { SearchResultComponent } from './components/search/search-result.component';

// services
import { RegistrationService } from './services/registration.service';
import { LocalizationService } from './services/localization.service';
import { AuthenticationService } from './services/authentication.service';
import { SystemService } from './services/system.service';

import { AppRoutingModule } from './app-routing.module';

// 3rd party modules
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { Ng2DatetimePickerModule } from 'ng2-datetime-picker';
import { NgUploaderModule } from 'ngx-uploader';

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
        MaritalStatusComponent,
        DropdownComponent,
        MultiDropdownComponent,
        DatepickerComponent,
        SearchResultComponent
    ],
    providers: [
        AuthGuard,
        RegistrationService,
        LocalizationService,
        AuthenticationService,
        SystemService
    ],
    imports: [
        AppRoutingModule,
        FormsModule,
        MultiselectDropdownModule,
        Ng2DatetimePickerModule,
        NgUploaderModule,
        BrowserAnimationsModule
    ]
};
