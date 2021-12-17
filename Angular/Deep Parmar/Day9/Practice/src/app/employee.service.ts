import { Injectable } from '@angular/core';
import { IEmployee } from './Employee.Model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor() { }

  EmployeeList:IEmployee[]=[
    {ID:12,Name:"Bharat",Age:21,Department:"QA"},
    {ID:13,Name:"Ramesh",Age:24,Department:".Net"},
    {ID:14,Name:"Suresh",Age:25,Department:"HR"},
  ];

  AddEmployee(Employee:IEmployee):void
  {
    this.EmployeeList.push(Employee);
  }

  GetEmployees()
  {
    return this.EmployeeList;
  }
}
