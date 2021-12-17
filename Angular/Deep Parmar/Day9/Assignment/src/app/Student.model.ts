interface ParentData
{
  fullName:object;
  email:string;
  educationQualification:string;
  profession:string;
  designation:string;
  phone:number;
}

interface Address{
    city:string;
    state:string;
    country:string;
    pin:string;
}

interface EmergencyContact{
    relation:string;
    number:string;
}

export interface IStudent
{
  studentName:string;
  dob:Date;
  placeofBirth:string;
  firstLanguage:string;
  address:Address;
  fatherInfo:ParentData;
  motherInfo:ParentData;
  emergencyContact:EmergencyContact;
  referenceDetails:string;
  referenceThrough:string;
  arddressWithTelNo:string;
}
