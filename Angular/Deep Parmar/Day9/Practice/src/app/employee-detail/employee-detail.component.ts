import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../Employee.Model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  constructor(private Employee:EmployeeService) { }

  ngOnInit(): void {
  }

  EmployeeList:IEmployee[]=this.Employee.GetEmployees();

}
