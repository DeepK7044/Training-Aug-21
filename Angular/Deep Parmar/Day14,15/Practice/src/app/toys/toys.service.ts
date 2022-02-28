import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToysService {

  url:string='api/Product';
  constructor(private http:HttpClient) { }

  public GetToys():Observable<Itoys[]>
  {
    return this.http.get<Itoys[]>(this.url);
  }

}

interface Itoys{
  ToysId:number, 
  ToyName:string, 
  UnitPrice:string, 
  ToyQuantity:string, 
  AvailabilityStatus:string, 
  PlantId:number 
}


