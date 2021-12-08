interface ParentData
{
  fullName:object;
  email:string;
  educationQualification:string;
  profession:string;
  designation:string;
  phone:number;
}

export interface Student
{
  studentName:string;
  dob:Date;
  placeofBirth:string;
  firstLanguage:string;
  address:object;
  fatherInfo:ParentData;
  motherInfo:ParentData;
  emergencyContact:object;
  referenceDetails:string;
  referenceThrough:string;
  arddressWithTelNo:string;
}
