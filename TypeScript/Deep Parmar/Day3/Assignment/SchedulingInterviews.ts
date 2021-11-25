import * as vacancies from "./vacancies"
import * as Applicants from "./Applicants"

export class ScheduleInterview
{
    InterviewId:number;
    InterviewerId:number;
    VacancyId:number;
    ApplicantId:number;
    DateAndTime: Date;

    constructor(InterviewId:number,InterviewerId:number,VacancyId:number,ApplicantId:number,DateAndTime:string)
    {
        this.InterviewId=InterviewId;
        this.InterviewerId=InterviewerId;
        this.VacancyId=VacancyId;
        this.ApplicantId=ApplicantId;
        this.DateAndTime=new Date(DateAndTime);
    }
}

export let AllScheduleInterview:ScheduleInterview[]=[
    {"InterviewId":1001,"InterviewerId":112,"VacancyId":1,"ApplicantId":101,"DateAndTime":new Date("2019-01-16 10:00 AM")},
    {"InterviewId":1002,"InterviewerId":113,"VacancyId":1,"ApplicantId":105,"DateAndTime":new Date("2019-01-16 10:30 AM")},
    {"InterviewId":1003,"InterviewerId":114,"VacancyId":3,"ApplicantId":102,"DateAndTime":new Date("2019-01-16 11:00 AM")},
    {"InterviewId":1004,"InterviewerId":115,"VacancyId":2,"ApplicantId":103,"DateAndTime":new Date("2019-01-16 11:30 AM")},
    {"InterviewId":1005,"InterviewerId":116,"VacancyId":4,"ApplicantId":104,"DateAndTime":new Date("2019-01-16 12:30 PM")},
]

export function CheckAppliedApplicantValid(ApplicantId:number):boolean
{
    let status:boolean;
    Applicants.AllApplicants.filter((Applicant,index,array) => {
        if(Applicant.ApplicantId==ApplicantId)
        {
            status=true;
        }
    });
    return status;
}

//Add Scheduling Interviews
export function AddScheduleInterview(InterviewId:number,InterviewerId:number,VacancyId:number,ApplicantId:number,DateAndTime:string)
{
    if(CheckAppliedApplicantValid(ApplicantId) && Applicants.CheckAppliedVacancyValid(VacancyId))
    {
        var InterviewObj=new ScheduleInterview(InterviewId,InterviewerId,VacancyId,ApplicantId,DateAndTime);
        AllScheduleInterview.push(InterviewObj);
    }
    else
    {
        if(! CheckAppliedApplicantValid(ApplicantId))
        {
            console.log("Please Enter Valid ApplicantId..");
        }
        else if(! Applicants.CheckAppliedVacancyValid(VacancyId))
        {
            console.log("Please Enter Valid VacancyId..")
        }
    }
}

//Display Scheduling Interviews
export function DisplayScheduleInterviews()
{
    AllScheduleInterview.forEach(element => {
        console.log(element);
    });
}

//Selection Process
export function SelectionProcess()
{
    vacancies.AllVacancies.forEach(Vacancy => {
        Applicants.AllApplicants.forEach(Applicant => {
            if(Vacancy.ExperienceRequired<=Applicant.Experience 
                && Vacancy.PassoutYearRequire==Applicant.PassoutYear 
                && Vacancy.TechnologyName==Applicant.Skills)
                {
                    Applicant.IsSelected=true;
                }            
        });
    });
} 

//Selected Applicant
export function SelectedApplicant()
{
    Applicants.AllApplicants.filter((Applicant,index,array)=>{
        if(Applicant.IsSelected==true)
        {
            console.log(Applicant);
        }
    });
}

//Report
export function Report()
{
    Applicants.AllApplicants.forEach(element => {
        console.log(element);
    });
}


