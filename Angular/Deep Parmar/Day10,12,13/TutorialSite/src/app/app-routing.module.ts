import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HTMLComponent } from './html/html.component';
import { CSSComponent } from './css/css.component';
import { JavaScriptComponent } from './java-script/java-script.component';
import { AngularComponent } from './angular/angular.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoggedinguardService } from './loggedinguard.service';

const routes: Routes = [
  {path:"HTML",
  component:HTMLComponent,
  loadChildren:()=>import('./html/html.module').then(m=>m.HtmlModule)
  },
  {path:"CSS",component:CSSComponent,canActivate:[LoggedinguardService]},
  {path:"JavaScript",component:JavaScriptComponent,canActivate:[LoggedinguardService]},
  {path:"Angular",component:AngularComponent},
  {path:"",redirectTo:"/HTML",pathMatch:"full"},
  {path:"**",component:PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
