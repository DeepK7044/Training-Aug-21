import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTMLComponent } from './html/html.component';
import { CSSComponent } from './css/css.component';
import { AngularComponent } from './angular/angular.component';
import { JavaScriptComponent } from './java-script/java-script.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AssignmentComponent } from './html/Day1/assignment/assignment.component';
import { PracticeExercis1Component } from './html/Day1/Practice/practice-exercis1/practice-exercis1.component';
import { PracticeExercis2Component } from './html/Day1/Practice/practice-exercis2/practice-exercis2.component';
import { PracticeExercis3Component } from './html/Day1/Practice/practice-exercis3/practice-exercis3.component';
import { PracticeExercis4Component } from './html/Day1/Practice/practice-exercis4/practice-exercis4.component';
import { PracticeExercis5Component } from './html/Day1/Practice/practice-exercis5/practice-exercis5.component';
import { HtmlHomeComponent } from './html/html-home/html-home.component';
import { LoginComponent } from './login/login.component';
import { HtmlRoutingModule } from './html/html-routing.module';
import { LoggedinguardService } from './loggedinguard.service';
import { AUTH_PROVIDERS, AuthService } from './auth.service';


@NgModule({
  declarations: [
    AppComponent,
    HTMLComponent,
    CSSComponent,
    AngularComponent,
    JavaScriptComponent,
    PageNotFoundComponent,
    AssignmentComponent,
    PracticeExercis1Component,
    PracticeExercis2Component,
    PracticeExercis3Component,
    PracticeExercis4Component,
    PracticeExercis5Component,
    HtmlHomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HtmlRoutingModule
  ],
  providers: [LoggedinguardService,AUTH_PROVIDERS,AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
