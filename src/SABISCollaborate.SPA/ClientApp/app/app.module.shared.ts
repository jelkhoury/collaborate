import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AuthGuard } from './_guards/auth.guard';

// component
import { AppComponent } from './components/app/app.component'
import { LoginComponent } from './components/login/login.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ManageUsersComponent } from './components/management/users.component';
import { ManagementDepartmentsComponent } from './components/departments/departments.component';
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
        NavMenuComponent,
        ManageUsersComponent,
        ManagementDepartmentsComponent
        ManageUsersComponent,
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
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            //{ path: '**', redirectTo: 'home' },
            { path: 'management/users', component: ManageUsersComponent },
            { path: 'departments', component: ManagementDepartmentsComponent }
        ])
    ]
};
