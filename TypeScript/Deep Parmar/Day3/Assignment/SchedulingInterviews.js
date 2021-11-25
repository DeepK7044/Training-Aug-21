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
    { "InterviewId": 1005, "InterviewerId": 116, "VacancyId": 4, "ApplicantId": 104, "DateAndTime": new Date("2019-01-16 12:30 AM") },
];
function CheckAppliedApplicantValid(ApplicantId) {
    Applicants.AllApplicants.filter(function (Applicant, index, array) {
        if (Applicant.ApplicantId == ApplicantId) {
            return true;
        }
    });
    return false;
}
exports.CheckAppliedApplicantValid = CheckAppliedApplicantValid;
function AddScheduleInterview(InterviewId, InterviewerId, VacancyId, ApplicantId, DateAndTime) {
    if (CheckAppliedApplicantValid(ApplicantId) && Applicants.CheckAppliedVacancyValid(VacancyId)) {
        var InterviewObj = new ScheduleInterview(InterviewId, InterviewerId, VacancyId, ApplicantId, DateAndTime);
        exports.AllScheduleInterview.push(InterviewObj);
    }
}
exports.AddScheduleInterview = AddScheduleInterview;
function DisplayScheduleInterviews() {
    exports.AllScheduleInterview.forEach(function (element) {
        console.log(element);
    });
}
exports.DisplayScheduleInterviews = DisplayScheduleInterviews;
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
function SelectedApplicant() {
    Applicants.AllApplicants.filter(function (Applicant, index, array) {
        if (Applicant.IsSelected == true) {
            console.log(Applicant);
        }
    });
}
exports.SelectedApplicant = SelectedApplicant;
function Report() {
    Applicants.AllApplicants.forEach(function (element) {
        console.log(element);
    });
}
exports.Report = Report;
