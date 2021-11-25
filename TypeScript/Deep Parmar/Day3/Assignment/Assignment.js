"use strict";
// This project is aimed at developing a web-based and central Recruitment Process System for the HR Group for a company.
//  Some features of this system will be creating vacancies, storing Applicants data, Interview process initiation, 
//  Scheduling Interviews, Storing Interview results for the applicant and finally Hiring of the applicant.
//  Reports may be required to be generated for the use of HR group.
exports.__esModule = true;
var vacancies = require("./vacancies");
var Applicants = require("./Applicants");
var SchedulingInterviews = require("./SchedulingInterviews");
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
var Choice = 9;
switch (Choice) {
    case 1:
        vacancies.AddVacancy(5, "Android Devlopment", 2021, "B.E.", 1, 15, 400000, true);
        vacancies.DisplayVacancies();
        break;
    case 2:
        vacancies.DisplayVacancies();
        break;
    case 3:
        vacancies.AddVacancy(5, "Android Devlopment", 2021, "B.E.", 1, 15, 400000, true);
        Applicants.AddApplicant(108, "Sumit", "Sumit@gmail.com", 9989898989, 2018, "B.E.", "Android Devlopment", 1, 5, false);
        Applicants.DisplayApplicants();
        break;
    case 4:
        Applicants.DisplayApplicants();
        break;
    case 5:
        vacancies.AddVacancy(5, "Android Devlopment", 2021, "B.E.", 1, 15, 400000, true);
        Applicants.AddApplicant(108, "Sumit", "Sumit@gmail.com", 9989898989, 2018, "B.E.", "Android Devlopment", 1, 5, false);
        SchedulingInterviews.AddScheduleInterview(1006, 118, 5, 108, "2019-01-16 1:00 PM");
        SchedulingInterviews.DisplayScheduleInterviews();
        break;
    case 6:
        SchedulingInterviews.DisplayScheduleInterviews();
        break;
    case 7:
        SchedulingInterviews.SelectionProcess();
        Applicants.DisplayApplicants();
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
