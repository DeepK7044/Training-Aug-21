import { Component, OnInit } from '@angular/core';
import { FormGroup, EmailValidator } from '@angular/forms';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  loginForm:boolean=false;
  registerForm:boolean=false;
  Auhenticate:boolean=false;

  countryList:country[] = [
    new country("1", "India"),
    new country('2', 'USA'),
    new country('3', 'England')
  ];

  submit(signinForm:FormGroup)
  {
    console.log(signinForm.value);
  }
  RegisterFormSubmit(signinForm:FormGroup)
  {
    console.log(signinForm.value);
  }

  signinFormShow()
  {
    this.loginForm=!this.loginForm
  }
  signupFormShow()
  {
    this.registerForm=!this.registerForm
  }
  LoginUser(email:any,password:any)
  {
    if(email=='parmardeep2018@gmail.com' && password==12345)
    {
      this.Auhenticate=true;
    }
  }
}
export class country {
  id:string;
  name:string;
 
  constructor(id:string, name:string) {
    this.id=id;
    this.name=name;
  }
}