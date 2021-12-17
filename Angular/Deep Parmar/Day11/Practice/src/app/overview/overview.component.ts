import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { ProductService } from '../product.service';
import { Product } from '../Product';
 
@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
})
export class OverviewComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


}
