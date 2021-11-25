// This project is aimed at developing a web-based and central Recruitment Process System for the HR Group for a company.
//  Some features of this system will be creating vacancies, storing Applicants data, Interview process initiation, 
//  Scheduling Interviews, Storing Interview results for the applicant and finally Hiring of the applicant.
//  Reports may be required to be generated for the use of HR group.

import * as vacancies from "./vacancies"
import * as Applicants from "./Applicants"
import * as SchedulingInterviews from "./SchedulingInterviews"

// Choice
//1.Add vacancy
//2.Display All vacancies
//3.Add Applicant
//4.Display All Applicant
//5.Add Scheduling Interviews
//6.Display Scheduling Interviews
//7.SelectionProcess
//8.SelectedApplicant
//9.Report

let Choice:number=9;

switch (Choice) {
    case 1:
        vacancies.AddVacancy(5,"Android Devlopment",2021,"B.E.",1,15,400000,true);       
        break;
    case 2:
        vacancies.DisplayVacancies();        
        break;
    case 3:
        Applicants.AddApplicant(108,"Sumit","Sumit@gmail.com",9989898989,2018,"B.E.","Android Devlopment",1,3,false);    
        break;
    case 4:
        Applicants.DisplayApplicants();        
        break;
    case 5:
        SchedulingInterviews.AddScheduleInterview(1006,118,5,108,"2019-01-16 1:00 PM");      
        break;
    case 6:
        SchedulingInterviews.DisplayScheduleInterviews();        
        break;
    case 7:
        SchedulingInterviews.SelectionProcess();      
        break;
    case 8:
        SchedulingInterviews.SelectionProcess();      
        SchedulingInterviews.SelectedApplicant();       
        break;
    case 9:
        SchedulingInterviews.SelectionProcess();      
        SchedulingInterviews.Report();        
        break;
    default:
        break;
}