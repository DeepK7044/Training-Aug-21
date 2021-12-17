import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import {SigninComponent} from './signin/signin.component'
import { AppComponent } from './app.component';
import { DynamicFormComponent } from './dynamic-form.component';
import { DynamicFormQuestionComponent } from './dynamic-form-question.component';
import { from } from 'rxjs';

@NgModule({
  imports: [ BrowserModule,FormsModule, ReactiveFormsModule ],
  declarations: [ AppComponent,DynamicFormComponent, DynamicFormQuestionComponent ,SigninComponent],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  constructor() {
  }
}