import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Username='';
  Password='';

  constructor() { }

  ngOnInit(): void {
  }
  
  Login()
  {
    
    if (this.Password=='admin' && this.Username=='admin') {
      
      alert("Thank You For Login");

    }
    else
    {
      alert("Please Enter Valid Username & Password");
    }
  }

}
