import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { SystemService, Department } from '../../services/system.service';



@Component({
    selector: 'department',
    templateUrl: './departments.component.html',
    providers: [SystemService]
})

export class ManagementDepartmentsComponent {
    public departments: Department[];
    private _departmentService: SystemService;

    public departmentName;
    public valid = false;

    constructor(SystemService: SystemService) {
        this._departmentService = SystemService;

        this.getDepartments();

        //this._departmentService.addDepartment(this.departmentName).subscribe(result => {
        //    this.departments = result.json() as Department[];
        //    console.log(this.departments);
        //});

        

    }

    public addDepartment() {
        this._departmentService.addDepartment(this.departmentName).subscribe(result => {
            this.getDepartments();
            this.departmentName = "";
        });
    }
    public getDepartments() {
        this._departmentService.getDepartment().subscribe(result => {
            this.departments = result.json() as Department[];
            console.log(this.departments);
        });
    }
    
}

