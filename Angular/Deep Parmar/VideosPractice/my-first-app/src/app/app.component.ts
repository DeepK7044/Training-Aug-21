import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  // styles:[`
  // h2{
  //   color:cadetblue;
  // }
  // h3{color:blue;}`]
})
export class AppComponent {
  title = 'my app';
  Name="Deep";
  Username='';
  IsDisplay=false;
  log:any= [];

  Toggle()
  {
    // this.log.push(this.log.length + 1);
    this.log.push(new Date());
    this.IsDisplay=!this.IsDisplay;
  }
}


