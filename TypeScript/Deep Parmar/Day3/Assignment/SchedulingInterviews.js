"use strict";
exports.__esModule = true;
exports.Report = exports.SelectedApplicant = exports.SelectionProcess = exports.DisplayScheduleInterviews = exports.AddScheduleInterview = exports.CheckAppliedApplicantValid = exports.AllScheduleInterview = exports.ScheduleInterview = void 0;
var vacancies = require("./vacancies");
var Applicants = require("./Applicants");
var ScheduleInterview = /** @class */ (function () {
    function ScheduleInterview(InterviewId, InterviewerId, VacancyId, ApplicantId, DateAndTime) {
        this.InterviewId = InterviewId;
        this.InterviewerId = InterviewerId;
        this.VacancyId = VacancyId;
        this.ApplicantId = ApplicantId;
        this.DateAndTime = new Date(DateAndTime);
    }
    return ScheduleInterview;
}());
exports.ScheduleInterview = ScheduleInterview;
exports.AllScheduleInterview = [
    { "InterviewId": 1001, "InterviewerId": 112, "VacancyId": 1, "ApplicantId": 101, "DateAndTime": new Date("2019-01-16 10:00 AM") },
    { "InterviewId": 1002, "InterviewerId": 113, "VacancyId": 1, "ApplicantId": 105, "DateAndTime": new Date("2019-01-16 10:30 AM") },
    { "InterviewId": 1003, "InterviewerId": 114, "VacancyId": 3, "ApplicantId": 102, "DateAndTime": new Date("2019-01-16 11:00 AM") },
    { "InterviewId": 1004, "InterviewerId": 115, "VacancyId": 2, "ApplicantId": 103, "DateAndTime": new Date("2019-01-16 11:30 AM") },
    { "InterviewId": 1005, "InterviewerId": 116, "VacancyId": 4, "ApplicantId": 104, "DateAndTime": new Date("2019-01-16 12:30 PM") },
];
function CheckAppliedApplicantValid(ApplicantId) {
    var status;
    Applicants.AllApplicants.filter(function (Applicant, index, array) {
        if (Applicant.ApplicantId == ApplicantId) {
            status = true;
        }
    });
    return status;
}
exports.CheckAppliedApplicantValid = CheckAppliedApplicantValid;
//Add Scheduling Interviews
function AddScheduleInterview(InterviewId, InterviewerId, VacancyId, ApplicantId, DateAndTime) {
    if (CheckAppliedApplicantValid(ApplicantId) && Applicants.CheckAppliedVacancyValid(VacancyId)) {
        var InterviewObj = new ScheduleInterview(InterviewId, InterviewerId, VacancyId, ApplicantId, DateAndTime);
        exports.AllScheduleInterview.push(InterviewObj);
    }
    else {
        if (!CheckAppliedApplicantValid(ApplicantId)) {
            console.log("Please Enter Valid ApplicantId..");
        }
        else if (!Applicants.CheckAppliedVacancyValid(VacancyId)) {
            console.log("Please Enter Valid VacancyId..");
        }
    }
}
exports.AddScheduleInterview = AddScheduleInterview;
//Display Scheduling Interviews
function DisplayScheduleInterviews() {
    exports.AllScheduleInterview.forEach(function (element) {
        console.log(element);
    });
}
exports.DisplayScheduleInterviews = DisplayScheduleInterviews;
//Selection Process
function SelectionProcess() {
    vacancies.AllVacancies.forEach(function (Vacancy) {
        Applicants.AllApplicants.forEach(function (Applicant) {
            if (Vacancy.ExperienceRequired <= Applicant.Experience
                && Vacancy.PassoutYearRequire == Applicant.PassoutYear
                && Vacancy.TechnologyName == Applicant.Skills) {
                Applicant.IsSelected = true;
            }
        });
    });
}
exports.SelectionProcess = SelectionProcess;
//Selected Applicant
function SelectedApplicant() {
    Applicants.AllApplicants.filter(function (Applicant, index, array) {
        if (Applicant.IsSelected == true) {
            console.log(Applicant);
        }
    });
}
exports.SelectedApplicant = SelectedApplicant;
//Report
function Report() {
    Applicants.AllApplicants.forEach(function (element) {
        console.log(element);
    });
}
exports.Report = Report;
