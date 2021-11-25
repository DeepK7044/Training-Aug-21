import * as vacancies from "./vacancies"

export class Applicants
{
    ApplicantId:number;
    ApplicantName:string;
    EmailAddress:string;
    PhoneNumber:number;
    PassoutYear:number;
    Qualification:string;
    Skills:string;
    Experience:number;
    AppliedVacancyId:number;
    IsSelected:boolean;

    constructor(ApplicantId:number,ApplicantName:string,EmailAddress:string
                ,PhoneNumber:number,PassoutYear:number,Qualification:string
                ,Skills:string, Experience:number,AppliedVacancyId:number,IsSelected:boolean)
    {
    this.ApplicantId=ApplicantId;
    this.ApplicantName=ApplicantName;
    this.EmailAddress=EmailAddress;
    this.PhoneNumber=PhoneNumber;
    this.PassoutYear=PassoutYear;
    this.Qualification=Qualification;
    this.Skills=Skills;
    this.Experience=Experience;
    this.AppliedVacancyId=AppliedVacancyId;
    this.IsSelected=IsSelected;
    }
}

export let AllApplicants:Applicants[]=
[
    {"ApplicantId":101,"ApplicantName":"Deep","EmailAddress":"Deep@gmail.com","PhoneNumber":8989898989,"PassoutYear":2021,"Qualification":"B.E.","Skills":".NET","Experience":2,"AppliedVacancyId":1,"IsSelected":false},
    {"ApplicantId":102,"ApplicantName":"Reema","EmailAddress":"Reema@gmail.com","PhoneNumber":9989898989,"PassoutYear":2018,"Qualification":"B.E.","Skills":"Node","Experience":1,"AppliedVacancyId":3,"IsSelected":false},
    {"ApplicantId":103,"ApplicantName":"Ramesh","EmailAddress":"Ramesh@gmail.com","PhoneNumber":8984498989,"PassoutYear":2019,"Qualification":"B.E.","Skills":"React","Experience":2,"AppliedVacancyId":2,"IsSelected":false},
    {"ApplicantId":104,"ApplicantName":"Dhruvesh","EmailAddress":"Dhruvesh@gmail.com","PhoneNumber":9089898989,"PassoutYear":2021,"Qualification":"B.E.","Skills":"Artificial Intelligence","Experience":4,"AppliedVacancyId":4,"IsSelected":false},
    {"ApplicantId":105,"ApplicantName":"Gita","EmailAddress":"Gita@gmail.com","PhoneNumber":8689898989,"PassoutYear":2021,"Qualification":"B.E.","Skills":".NET","Experience":2,"AppliedVacancyId":1,"IsSelected":false}
];

export function CheckAppliedVacancyValid(Id:number):boolean
{
    var status:boolean;
    vacancies.AllVacancies.filter((Vacancy,index,array) => {
        if(Vacancy.ID==Id)
        {
            status= true;
        }
    });
    return status;
}


//Add Applicant
export function AddApplicant(ApplicantId:number,ApplicantName:string,EmailAddress:string
    ,PhoneNumber:number,PassoutYear:number,Qualification:string
    ,Skills:string,Experience:number,AppliedVacancyId:number,IsSelected:boolean)
{
    var status:boolean=CheckAppliedVacancyValid(AppliedVacancyId);
    if(status)
    {
        var ApplicantObj=new Applicants(ApplicantId,ApplicantName,EmailAddress,PhoneNumber
                                        ,PassoutYear,Qualification,Skills,Experience,AppliedVacancyId,IsSelected);
        
        AllApplicants.push(ApplicantObj);                                  
    }
    else
    {
        console.log("Please Enter Valid VacancyId..");
    }

}

//Display All Applicant
export function DisplayApplicants()
{
    AllApplicants.forEach(element => {
        console.log(element);
    });
}