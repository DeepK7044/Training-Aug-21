import { Component, OnInit } from '@angular/core';
import {StudentService} from '../student.service'
import { IStudent } from '../Student.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  constructor(private StudentService:StudentService) { }

  tableStatus:boolean=false;

  ngOnInit(): void {
  }

  studentList:IStudent[]=this.StudentService.getStudent();

  DeleteStudent(index:number)
  {
    this.StudentService.deleteStudent(index);
  }

  showTable()
  {
    this.tableStatus=!this.tableStatus;
  }
}
