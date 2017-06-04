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

// services
import { UsersService } from './services/users.service';
import { LocalizationService } from './services/localization.service';
import { AuthenticationService } from './services/authentication.service';

import { AppRoutingModule } from './app-routing.module';

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
        GenderComponent
    ],
    providers: [
        AuthGuard,
        UsersService,
        LocalizationService,
        AuthenticationService
    ],
    imports: [
        AppRoutingModule,
        FormsModule
    ]
};
