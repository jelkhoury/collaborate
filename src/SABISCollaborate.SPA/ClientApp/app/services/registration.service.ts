import { Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Gender, Department, MaritalStatus } from '../shared/models';

@Injectable()
export class RegistrationService {
    private url: string;
    private http: Http;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.url = originUrl;
        this.http = http;
    }

    getUsers(): Observable<Response> {
        return this.http.get(this.url + '/api/management/users');
    }

    getInitRegistrationModel(): Observable<Response> {
        return this.http.get(this.url + '/api/management/registration');
    }

    register(username: string,
        password: string,
        email: string,
        nickname: string,
        firstName: string,
        lastName: string,
        maritalStatus: MaritalStatus,
        gender: Gender,
        birthDate: Date,
        departmentsIds: number[],
        positionId: number,
        employmentDate: Date): Observable<Response> {
        return this.http.post(this.url + '/api/management/registration', {
            Username: username,
            Password: password,
            Email: email,
            Nickname: nickname,
            FirstName: firstName,
            LastName: lastName,
            MaritalStatus: maritalStatus,
            Gender: gender,
            BirthDate: birthDate,
            DepartmentsIds: departmentsIds,
            PositionId: positionId,
            EmploymentDate: employmentDate
        });
    }
}

export interface User {
    id: number,
    username: string;
    profile: UserProfile;
}

export interface UserProfile {
    firstName: string;
    lastName: string;
}