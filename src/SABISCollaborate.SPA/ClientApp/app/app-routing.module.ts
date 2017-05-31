import { NgModule } from '@angular/core';
import { Route, Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';
import { AuthenticationService } from './services/authentication.service';

import { LoginComponent } from './components/login/login.component';
import { ManageUsersComponent } from './components/management/users.component';
import { RegistrationComponent } from './components/management/registration.component';
import { ManagementDepartmentsComponent } from './components/departments/departments.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'management/users', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
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