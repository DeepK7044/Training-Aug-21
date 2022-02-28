import { Component, OnInit } from '@angular/core';
import { ToysService } from './toys.service';

@Component({
  selector: 'app-toys',
  templateUrl: './toys.component.html',
  styleUrls: ['./toys.component.css']
})
export class ToysComponent implements OnInit {

  constructor(private _ToysService:ToysService) { }

  Toys:any=[]

  ngOnInit(): void {
    this._ToysService.GetToys().subscribe(data=>{      
      this.Toys=data;
    })    
  }

  
}
