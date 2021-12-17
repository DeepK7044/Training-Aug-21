import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../Employee.Model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {


  constructor(private Employee:EmployeeService) { }

  ngOnInit(): void {
  }

  EmployeeList:IEmployee[]=this.Employee.GetEmployees();

}
