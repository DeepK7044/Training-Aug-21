import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() studentList:any[]=[];

  tableStatus:boolean=false;

  showTable()
  {
    this.tableStatus=!this.tableStatus;
  }

}