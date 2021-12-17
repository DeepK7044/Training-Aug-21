import { Component } from '@angular/core';
import {product} from './product-list/productModel'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Practice';
  
  ProductArr:product[]=[];

  AddData(Product:any[])
  {
    this.ProductArr=Product; 
  }

}
