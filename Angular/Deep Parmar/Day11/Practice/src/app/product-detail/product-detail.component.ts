import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
 
import { ProductService } from '../product.service';
import { Product } from '../Product';
 
 
@Component({
  templateUrl: './product-detail.component.html',
})
 
export class ProductDetailComponent
{
   product:any;
   id:number=0;
   sub:string='';
 
   constructor(private _Activatedroute:ActivatedRoute,
               private _router:Router,
               private _productService:ProductService){
   }
 
   ngOnInit() {
       this.id=this._Activatedroute.snapshot.params['id'];
       let products=this._productService.getProducts();
       this.product=products.find(p => p.productID==this.id);
   }
  
}