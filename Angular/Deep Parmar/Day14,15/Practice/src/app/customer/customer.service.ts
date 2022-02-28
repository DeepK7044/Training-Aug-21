import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICustomer } from './customer-details/customer-details.component';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  url:string="api";
  constructor(private http:HttpClient) { }

  getCustomers()
  {
    let endPoint="/Customer";
    return this.http.get(this.url+endPoint);
  }

  AddCustomer(customer:any)
  {
    let endPoint="/Customer";
    // console.log("HII"+customer);
    let headers = new HttpHeaders();
    headers.append('content-type', 'application/json')
    this.http.post(this.url+endPoint,customer,{headers:headers}).subscribe(data => {​
      console.log(data);​
    });
  }

  delete(Id:number)
  {
    let endPoint="/Customer/"+Id;
    return this.http.delete(this.url+endPoint);
  }

  getCustomer(Id:number):Observable<ICustomer>
  {
    let endPoint="/Customer/"+Id;
    return this.http.get<ICustomer>(this.url+endPoint);
  }

  editCustomer(customer:ICustomer,Id:number)
  {
    let endPoint="/Customer/"+Id;
    let headers = new HttpHeaders();
    headers.append('content-type', 'application/json')
    return this.http.put(this.url+endPoint,customer,{headers:headers});
  }

}
