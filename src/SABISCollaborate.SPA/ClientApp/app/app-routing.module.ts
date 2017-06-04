import { NgModule } from '@angular/core';
import { Route, Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';
import { AuthenticationService } from './services/authentication.service';

import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ManageUsersComponent } from './components/management/users.component';
import { RegistrationComponent } from './components/management/registration.component';
import { ManagementDepartmentsComponent } from './components/management/departments.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    {
        path: 'management',
        children: [
            { path: 'users', component: ManageUsersComponent, canActivate: [AuthGuard] },
            { path: 'registration', component: RegistrationComponent, canActivate: [AuthGuard] },
            { path: 'departments', component: ManagementDepartmentsComponent, canActivate: [AuthGuard] }
        ]
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ],
    providers: [AuthenticationService, AuthGuard]
})

export class AppRoutingModule { }