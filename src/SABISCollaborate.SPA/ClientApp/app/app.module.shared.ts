import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component'
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
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        ManageUsersComponent,
        RegistrationComponent,
        GenderComponent
    ],
    providers: [UsersService, LocalizationService],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'management/users', pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            //{ path: '**', redirectTo: 'home' },
            { path: 'management/users', component: ManageUsersComponent },
            { path: 'management/register', component: RegistrationComponent }
        ]),
        FormsModule
    ]
};
