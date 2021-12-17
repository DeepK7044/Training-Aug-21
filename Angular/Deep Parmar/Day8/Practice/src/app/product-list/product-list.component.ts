import { Component, OnInit, Input } from '@angular/core';
import {product as Product} from './productModel'
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  @Input() ProductData:any[];

  constructor() {         
  }

  ngOnInit(): void {               
  }
  
  

}
