import { Injectable, Inject } from '@angular/core';
import { LoggerService } from './logger.service';
import {IStudent} from './Student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  StudentList:any[]=[];

  constructor(@Inject(LoggerService)private logger) {}

  AddStudent(studentData:IStudent):void
  {
    this.StudentList.push(studentData);
    this.logger.log("Student Add");    
  }

  getStudent():IStudent[]
  {
    return this.StudentList;
  }

  update(Student:IStudent):void
  {
    // this.StudentList.find((value,index,array)=>
    // {
    //   value.studentName=Student.studentName
    // })
    this.logger.log("Student Update");
  }

  deleteStudent(index:number):void
  {
    this.StudentList.splice(index,1);
    this.logger.log("Student Deleted");
  }

}
