import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ToysComponent } from './toys/toys.component';
import { CustomerComponent } from './customer/customer.component';
import { OrderComponent } from './order/order.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ToysComponent,
    CustomerComponent,
    OrderComponent,
    CustomerDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
