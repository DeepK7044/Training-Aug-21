import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-circle',
  templateUrl: './circle.component.html',
  styleUrls: ['./circle.component.css']
})
export class CircleComponent implements OnInit {

  pi:number=3.141592653589793238;
  Radius=null;
  Area=null;

  constructor() { }

  ngOnInit(): void {
  }

  CircleArea()
  {
    this.Area=this.pi*(this.Radius*this.Radius);
  }

}
