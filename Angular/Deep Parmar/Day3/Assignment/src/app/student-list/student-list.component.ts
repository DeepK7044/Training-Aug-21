import { Component, OnInit } from '@angular/core';

interface student
{
  ID:number;
  Name:string;
  Age:number;
  Average:number;
  grade:string;
  Active:boolean;
}

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})


export class StudentListComponent implements OnInit {

  ShowTable=false;
  ActiveStatus=true;

  constructor() { }

  ngOnInit(): void {
  }

  // Columns=[{ID:"ID",Name:'Name',Age:"Age",Average:"Average",grade:'grade',Active:"Active"}];

  Students:student[]=[
    {ID:1,Name:'Dhruvesh',Age:21,Average:80.25,grade:'A',Active:true},
    {ID:2,Name:'Chirag',Age:22,Average:70,grade:'B',Active:false},
    {ID:3,Name:'Pintu',Age:23,Average:92,grade:'A',Active:false},
    {ID:4,Name:'Meena',Age:22,Average:60.25,grade:'B',Active:true},
    {ID:5,Name:'Rohan',Age:23,Average:85.5,grade:'A',Active:false},
    {ID:6,Name:'Jay',Age:21,Average:25.5,grade:'F',Active:true},
    {ID:7,Name:'Parag',Age:22,Average:50,grade:'C',Active:true},
    {ID:8,Name:'Zeel',Age:21,Average:98,grade:'A',Active:true},
    {ID:9,Name:'Suresh',Age:22,Average:37,grade:'D',Active:true},
    {ID:10,Name:'Riddhi',Age:21,Average:75,grade:'B',Active:true}
  ]

  Toggle()
  {
    this.ShowTable=!this.ShowTable;
  }

  Active()
  {
    this.ActiveStatus=true;
  }
  InActive()
  {
    this.ActiveStatus=false;
  }

}
