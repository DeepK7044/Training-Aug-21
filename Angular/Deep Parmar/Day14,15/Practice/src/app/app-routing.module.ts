import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderComponent } from './order/order.component';
import { ToysComponent } from './toys/toys.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';

const routes: Routes = [
  {path:'order',component:OrderComponent},
  {path:'toys',component:ToysComponent},
  {path:'customer',component:CustomerComponent},
  {path:'customer/:id',component:CustomerDetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
