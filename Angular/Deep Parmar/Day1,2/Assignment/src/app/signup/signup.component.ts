import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  Name='';
  Address='';
  PanNumber=null;
  Result='';

  constructor() { }

  ngOnInit(): void {
  }

  SignUp()
  {
    this.Result=`Name=${this.Name},
            Address=${this.Address},
            PanNumber=${this.PanNumber}`;
    
  }

}
