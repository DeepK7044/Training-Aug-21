import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignmentComponent as Day1Assignment } from '../html/Day1/assignment/assignment.component';
import { AssignmentComponent as Day2Assignment} from '../html/Day2/assignment/assignment.component';
import { PracticeExercis1Component as Day1Practice1} from '../html/Day1/Practice/practice-exercis1/practice-exercis1.component';
import { PracticeExercis1Component } from '../html/Day2/Practice/practice-exercis1/practice-exercis1.component';
import { PracticeExercis2Component as Day1Practice2} from '../html/Day1/Practice/practice-exercis2/practice-exercis2.component';
import { PracticeExercis2Component } from '../html/Day2/Practice/practice-exercis2/practice-exercis2.component';
import { PracticeExercis3Component as Day1Practice3} from '../html/Day1/Practice/practice-exercis3/practice-exercis3.component';
import { PracticeExercis3Component } from '../html/Day2/Practice/practice-exercis3/practice-exercis3.component';
import { PracticeExercis4Component as Day1Practice4} from '../html/Day1/Practice/practice-exercis4/practice-exercis4.component';
import { PracticeExercis4Component } from '../html/Day2/Practice/practice-exercis4/practice-exercis4.component';
import { PracticeExercis5Component as Day1Practice5} from '../html/Day1/Practice/practice-exercis5/practice-exercis5.component';
import { PracticeExercis5Component } from '../html/Day2/Practice/practice-exercis5/practice-exercis5.component';
import { HtmlHomeComponent } from '../html/html-home/html-home.component';

const routes: Routes = [
  {path:"",component:HtmlHomeComponent},
  {path:"Day1/Assignment",component:Day1Assignment},
  {path:"Day1/Practice1",component:Day1Practice1},
  {path:"Day1/Practice2",component:Day1Practice2},
  {path:"Day1/Practice3",component:Day1Practice3},
  {path:"Day1/Practice4",component:Day1Practice4},
  {path:"Day1/Practice5",component:Day1Practice5},
  
  {path:"Day2/Practice1",component:PracticeExercis1Component},
  {path:"Day2/Practice2",component:PracticeExercis2Component},
  {path:"Day2/Practice3",component:PracticeExercis3Component},
  {path:"Day2/Practice4",component:PracticeExercis4Component},
  {path:"Day2/Practice5",component:PracticeExercis5Component},
  {path:"Day2/Assignment",component:Day2Assignment}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HtmlRoutingModule { }
