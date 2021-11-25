"use strict";
exports.__esModule = true;
exports.DisplayVacancies = exports.AddVacancy = exports.AllVacancies = exports.Vacancies = void 0;
var Vacancies = /** @class */ (function () {
    function Vacancies(ID, TechnologyName, PassoutYearRequire, QualificationRequired, ExperienceRequired, TotalVacancies, YearlyPackage, IsStatus) {
        this.ID = ID;
        this.TechnologyName = TechnologyName;
        this.PassoutYearRequire = PassoutYearRequire;
        this.QualificationRequired = QualificationRequired;
        this.ExperienceRequired = ExperienceRequired;
        this.TotalVacancies = TotalVacancies;
        this.YearlyPackage = YearlyPackage;
        this.IsStatus = IsStatus;
    }
    return Vacancies;
}());
exports.Vacancies = Vacancies;
exports.AllVacancies = [
    { "ID": 1, "TechnologyName": ".NET", "PassoutYearRequire": 2021, "QualificationRequired": "B.E.", "ExperienceRequired": 1, "TotalVacancies": 15, "YearlyPackage": 400000, "IsStatus": true },
    { "ID": 2, "TechnologyName": "React", "PassoutYearRequire": 2021, "QualificationRequired": "B.E.,B.Tech", "ExperienceRequired": 1, "TotalVacancies": 5, "YearlyPackage": 400000, "IsStatus": true },
    { "ID": 3, "TechnologyName": "Node", "PassoutYearRequire": 2021, "QualificationRequired": "B.E.", "ExperienceRequired": 2.5, "TotalVacancies": 8, "YearlyPackage": 500000, "IsStatus": true },
    { "ID": 4, "TechnologyName": "Artificial Intelligence", "PassoutYearRequire": 2021, "QualificationRequired": "B.E.,M.E", "ExperienceRequired": 2, "TotalVacancies": 2, "YearlyPackage": 600000, "IsStatus": true },
];
//Add vacancy
function AddVacancy(Id, TechnologyName, PassoutYearRequire, QualificationRequired, ExperienceRequired, TotalVacancies, YearlyPackage, IsStatus) {
    var VacancyObj = new Vacancies(Id, TechnologyName, PassoutYearRequire, QualificationRequired, ExperienceRequired, TotalVacancies, YearlyPackage, IsStatus);
    exports.AllVacancies.push(VacancyObj);
}
exports.AddVacancy = AddVacancy;
//Display All vacancies
function DisplayVacancies() {
    exports.AllVacancies.forEach(function (element) {
        console.log(element);
    });
}
exports.DisplayVacancies = DisplayVacancies;
