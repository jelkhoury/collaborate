import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';



@Component({
    selector: 'department',
    templateUrl: './departments.component.html'
})

export class ManagementDepartmentsComponent {
    public departments: Department[];
    public newdepartment;
    public valid = false;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        http.get(originUrl + '/api/management/departments').subscribe(result => {
            this.departments = result.json() as Department[];
            console.log(this.departments);
        });
    }

    public add() {
        alert(this.newdepartment);
    }
    
}

interface Department {
    department:string
}