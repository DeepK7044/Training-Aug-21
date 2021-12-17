import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import {product} from '../product-list/productModel'
import { from, combineLatest } from 'rxjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ProductArray:any=[];

  @Output() AddProducts=new EventEmitter(); 

  AddProduct(productId,productName,productPrice,productQuantity)
  {   
    this.ProductArray.push( {ProductId:productId,ProductName:productName,ProductPrice:productPrice,ProductQuantity:productQuantity,ProductStatus:true});
    this.AddProducts.emit(this.ProductArray);
  }

}
