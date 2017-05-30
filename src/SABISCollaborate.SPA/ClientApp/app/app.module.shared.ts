import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AuthGuard } from './_guards/auth.guard';

import { AppComponent } from './components/app/app.component'
import { LoginComponent } from './components/login/login.component'

import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ManageUsersComponent } from './components/management/users.component';
import { RegistrationComponent } from './components/management/registration.component';
import { GenderComponent } from './shared/components/gender.component';

import { UsersService } from './services/users.service';
import { LocalizationService } from './services/localization.service';

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        LoginComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        ManageUsersComponent,
        RegistrationComponent,
        GenderComponent
    ],
    providers: [
        AuthGuard,
        UsersService,
        LocalizationService
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'management/users', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: 'management/users', component: ManageUsersComponent, canActivate: [false] },
            { path: 'management/register', component: RegistrationComponent, canActivate: [false] },

            // otherwise redirect to home
            { path: '**', redirectTo: '' }
        ]),
        FormsModule
    ]
};
