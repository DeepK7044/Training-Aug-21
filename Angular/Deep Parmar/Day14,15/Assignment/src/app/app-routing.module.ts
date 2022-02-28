import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { StudentAdmissionComponent } from './student-admission/student-admission.component';

const routes: Routes = [
  {path:'Student',component:StudentComponent},
  {path:'StudentAdmission',component:StudentAdmissionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
