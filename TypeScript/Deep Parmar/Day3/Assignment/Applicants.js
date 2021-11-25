"use strict";
exports.__esModule = true;
exports.DisplayApplicants = exports.AddApplicant = exports.CheckAppliedVacancyValid = exports.AllApplicants = exports.Applicants = void 0;
var vacancies = require("./vacancies");
var Applicants = /** @class */ (function () {
    function Applicants(ApplicantId, ApplicantName, EmailAddress, PhoneNumber, PassoutYear, Qualification, Skills, Experience, AppliedVacancyId, IsSelected) {
        this.ApplicantId = ApplicantId;
        this.ApplicantName = ApplicantName;
        this.EmailAddress = EmailAddress;
        this.PhoneNumber = PhoneNumber;
        this.PassoutYear = PassoutYear;
        this.Qualification = Qualification;
        this.Skills = Skills;
        this.Experience = Experience;
        this.AppliedVacancyId = AppliedVacancyId;
        this.IsSelected = IsSelected;
    }
    return Applicants;
}());
exports.Applicants = Applicants;
exports.AllApplicants = [
    { "ApplicantId": 101, "ApplicantName": "Deep", "EmailAddress": "Deep@gmail.com", "PhoneNumber": 8989898989, "PassoutYear": 2021, "Qualification": "B.E.", "Skills": ".NET", "Experience": 2, "AppliedVacancyId": 1, "IsSelected": false },
    { "ApplicantId": 102, "ApplicantName": "Reema", "EmailAddress": "Reema@gmail.com", "PhoneNumber": 9989898989, "PassoutYear": 2018, "Qualification": "B.E.", "Skills": "Node", "Experience": 1, "AppliedVacancyId": 3, "IsSelected": false },
    { "ApplicantId": 103, "ApplicantName": "Ramesh", "EmailAddress": "Ramesh@gmail.com", "PhoneNumber": 8984498989, "PassoutYear": 2019, "Qualification": "B.E.", "Skills": "React", "Experience": 2, "AppliedVacancyId": 2, "IsSelected": false },
    { "ApplicantId": 104, "ApplicantName": "Dhruvesh", "EmailAddress": "Dhruvesh@gmail.com", "PhoneNumber": 9089898989, "PassoutYear": 2021, "Qualification": "B.E.", "Skills": "Artificial Intelligence", "Experience": 4, "AppliedVacancyId": 4, "IsSelected": false },
    { "ApplicantId": 105, "ApplicantName": "Gita", "EmailAddress": "Gita@gmail.com", "PhoneNumber": 8689898989, "PassoutYear": 2021, "Qualification": "B.E.", "Skills": ".NET", "Experience": 2, "AppliedVacancyId": 1, "IsSelected": false }
];
function CheckAppliedVacancyValid(Id) {
    vacancies.AllVacancies.filter(function (Vacancy, index, array) {
        if (Vacancy.ID == Id) {
            return true;
        }
    });
    return false;
}
exports.CheckAppliedVacancyValid = CheckAppliedVacancyValid;
function AddApplicant(ApplicantId, ApplicantName, EmailAddress, PhoneNumber, PassoutYear, Qualification, Skills, Experience, AppliedVacancyId, IsSelected) {
    if (CheckAppliedVacancyValid(AppliedVacancyId)) {
        var ApplicantObj = new Applicants(ApplicantId, ApplicantName, EmailAddress, PhoneNumber, PassoutYear, Qualification, Skills, Experience, AppliedVacancyId, IsSelected);
        exports.AllApplicants.push(ApplicantObj);
    }
    else {
        console.log("Please Enter Valid VacancyId..");
    }
}
exports.AddApplicant = AddApplicant;
function DisplayApplicants() {
    exports.AllApplicants.forEach(function (element) {
        console.log(exports.AllApplicants);
    });
}
exports.DisplayApplicants = DisplayApplicants;
