import { DisplayApplicants } from "./Applicants";

export class Vacancies
{
    ID:number;
    TechnologyName:string;
    PassoutYearRequire:number;
    QualificationRequired:string;
    ExperienceRequired:number;
    TotalVacancies:number;
    YearlyPackage:number;
    IsStatus:boolean;
    
    constructor(ID:number,TechnologyName:string,PassoutYearRequire:number
                ,QualificationRequired:string,ExperienceRequired:number,
                TotalVacancies:number,YearlyPackage:number,IsStatus:boolean) 
                
    {
        this.ID=ID;
        this.TechnologyName=TechnologyName;
        this.PassoutYearRequire=PassoutYearRequire;
        this.QualificationRequired=QualificationRequired;
        this.ExperienceRequired=ExperienceRequired;
        this.TotalVacancies=TotalVacancies;
        this.YearlyPackage=YearlyPackage;
        this.IsStatus=IsStatus;   
    }
}

export let AllVacancies:Vacancies[]=
[
    {"ID":1,"TechnologyName":".NET","PassoutYearRequire":2021,"QualificationRequired":"B.E.","ExperienceRequired":1,"TotalVacancies":15,"YearlyPackage":400000,"IsStatus":true},
    {"ID":2,"TechnologyName":"React","PassoutYearRequire":2021,"QualificationRequired":"B.E.,B.Tech","ExperienceRequired":1,"TotalVacancies":5,"YearlyPackage":400000,"IsStatus":true},
    {"ID":3,"TechnologyName":"Node","PassoutYearRequire":2021,"QualificationRequired":"B.E.","ExperienceRequired":2.5,"TotalVacancies":8,"YearlyPackage":500000,"IsStatus":true},
    {"ID":4,"TechnologyName":"Artificial Intelligence","PassoutYearRequire":2021,"QualificationRequired":"B.E.,M.E","ExperienceRequired":2,"TotalVacancies":2,"YearlyPackage":600000,"IsStatus":true},
];

//Add vacancy
export function AddVacancy(Id:number,TechnologyName:string,PassoutYearRequire:number
    ,QualificationRequired:string,ExperienceRequired:number,
    TotalVacancies:number,YearlyPackage:number,IsStatus:boolean)
    {
        var VacancyObj=new Vacancies(Id,TechnologyName,PassoutYearRequire,QualificationRequired,ExperienceRequired,
                                     TotalVacancies,YearlyPackage,IsStatus);
        AllVacancies.push(VacancyObj);
    }

//Display All vacancies
export function DisplayVacancies()
{
    AllVacancies.forEach(element => {
        console.log(element);
    });
}