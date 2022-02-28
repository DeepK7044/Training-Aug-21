import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../customer.service';

let customer:ICustomer;

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})

export class CustomerDetailsComponent implements OnInit {

  constructor(private router:ActivatedRoute,private _CustomerService:CustomerService) { }

  CusId:number=0;  
  CustomerName:string='';
  CustomerAge:number=0;
  PhoneNumber:string='';

  ngOnInit(): void {
    let id = parseInt(this.router.snapshot.params.id);
    this._CustomerService.getCustomer(id).subscribe(
      data=>{
        customer=data;
        this.CustomerName=data.customerName;
        this.CustomerAge=data.age;
        this.PhoneNumber=data.phoneNumber;
      }
    );
    this.CusId=id;
    
  }

  edit()
  {
    customer={customerId:this.CusId,customerName:this.CustomerName,age:this.CustomerAge,phoneNumber:this.PhoneNumber}
    this._CustomerService.editCustomer(customer,this.CusId).subscribe(data=>{console.log(data)});
  }

}

export interface ICustomer
{
  customerId:number
  customerName:string
  age:number
  phoneNumber:string
}


