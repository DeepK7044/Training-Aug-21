import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../Employee.Model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})


export class EmployeeComponent implements OnInit {

  constructor(private _Employeeservice:EmployeeService) { }

  ngOnInit(): void {
  }

  Employee:IEmployee;

  Add(name:string,age:number,department:string)
  {
    this.Employee={ID:123,Name:name,Age:age,Department:department};
    this._Employeeservice.AddEmployee(this.Employee);
  }
}



