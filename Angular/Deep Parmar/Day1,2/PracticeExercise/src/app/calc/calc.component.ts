import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calc',
  templateUrl: './calc.component.html',
  styleUrls: ['./calc.component.css']
})
export class CalcComponent implements OnInit {

  Result=0;
  number1=0;
  number2=0;

  constructor() { }

  ngOnInit(): void {
  }

  Addition()
  {
    this.Result=this.number1+this.number2;
  }

  Multiplication()
  {
    this.Result=this.number1*this.number2;
  }

  Substraction()
  {
    this.Result=this.number1-this.number2;
  }

  Division()
  {
    this.Result=this.number1/this.number2;
  }

}
