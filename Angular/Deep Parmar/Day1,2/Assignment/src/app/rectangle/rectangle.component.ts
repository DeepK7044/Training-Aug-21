import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css']
})
export class RectangleComponent implements OnInit {

  Lenght=null;
  Width=null;
  Area=null;

  constructor() { }

  ngOnInit(): void {
  }

  RectangleArea()
  {
    this.Area=this.Lenght*this.Width;
  }

}
