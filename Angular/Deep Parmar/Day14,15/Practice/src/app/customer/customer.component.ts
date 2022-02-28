import { Component, OnInit } from '@angular/core';
import { CustomerService } from './customer.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private CustomerService:CustomerService,private router:Router) { }

  Customer:any=[];
  tableshow:boolean=false; 

  ngOnInit(): void {
    this.CustomerService.getCustomers().subscribe(
      data=>{
        this.Customer=data;
        console.log(this.Customer);
      }
    )
  }

  Show()
  {
    this.tableshow=!this.tableshow;
  }

  Student:any=[]
  Add(Name:string,Age:string,PhoneNumber:string)
  {
    this.Student={customerName:Name,age:parseInt(Age, 10),phoneNumber:PhoneNumber};
    this.CustomerService.AddCustomer(this.Student);
    console.log(this.Student);
    this.router.navigate(['customer']);
  }

  delete(Id:number)
  {
    this.CustomerService.delete(Id).subscribe(data=>{
      console.log(data);
    });
  }

  edit(Id:number)
  {
    this.router.navigate(['/customer',Id]);
  }
}
