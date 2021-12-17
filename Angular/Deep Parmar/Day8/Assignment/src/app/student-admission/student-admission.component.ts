import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {FormBuilder, FormArray, Validators, FormControl} from '@angular/forms';
import {Student} from './studentModel';

@Component({
  selector: 'app-student-admission',
  templateUrl: './student-admission.component.html',
  styleUrls: ['./student-admission.component.css']
})
export class StudentAdmissionComponent implements OnInit {

  admissionStudent:Student[]=[];

  tableStatus:boolean=false;

  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
  }

  studentForm=this.fb.group({
    studentName:this.fb.group({
      firstName:['',Validators.required],
      middleName:['',Validators.required],
      lastName:['',Validators.required]
    }),

    dob:[null,Validators.required],
    placeofBirth:['',Validators.required],
    firstLanguage:['',Validators.required],

    address:this.fb.group({
      city:['',Validators.required],
      state:['',Validators.required],
      country:['',Validators.required],
      pin:['',[Validators.required,Validators.pattern("[0-9]{6}")]],
    }),

    fatherInfo:this.fb.group({
      fullName:this.fb.group({
        firstName:['',Validators.required],
        middleName:['',Validators.required],
        lastName:['',Validators.required]
      }),
        email:['',Validators.email],
        educationQualification:[''],
        profession:['',Validators.required],
        designation:['',Validators.required],
        phone:[null,[Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$"),Validators.required]],
    }),

    motherInfo:this.fb.group({
      fullName:this.fb.group({
        firstName:['',Validators.required],
        middleName:['',Validators.required],
        lastName:['',Validators.required]
      }),
      email:['',Validators.email],
      educationQualification:[''],
      profession:[''],
      designation:[''],
      phone:[null,[Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$"),Validators.required]],
    }),

    emergencyContact:this.fb.group({
      relation:this.fb.array([
        this.fb.control('',Validators.required)        
      ]),
      number:this.fb.array([
        this.fb.control(null,[Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$"),Validators.required])
      ])
    }),

    referenceDetails:[''],
    referenceThrough:[''],
    arddressWithTelNo:['']

  })


  get studentFirstName()
  {
    return this.studentForm.get('studentName').get('firstName') 
  }  
  get studentMiddleName()
  {
    return this.studentForm.get('studentName').get('middleName')
  }  
  get studentLastName()
  {
    return this.studentForm.get('studentName').get('lastName')
  }  
  get fatherFirstName()
  {
    return this.studentForm.get('fatherInfo').get('fullName').get('firstName') 
  }  
  get fatherMiddleName()
  {
    return this.studentForm.get('fatherInfo').get('fullName').get('middleName')
  }  
  get fatherLastName()
  {
    return this.studentForm.get('fatherInfo').get('fullName').get('lastName')
  }

  get motherFirstName()
  {
    return this.studentForm.get('motherInfo').get('fullName').get('firstName') 
  }  
  get motherMiddleName()
  {
    return this.studentForm.get('motherInfo').get('fullName').get('middleName')
  }  
  get motherLastName()
  {
    return this.studentForm.get('motherInfo').get('fullName').get('lastName')
  }

  get relation()
  {
    return this.studentForm.get('emergencyContact').get('relation') as FormArray
  }

  get number()
  {
    return this.studentForm.get('emergencyContact').get('number') as FormArray
  }
  get relationData()
  {
    return this.studentForm.get('emergencyContact').get('relation') 
  }

  get numberData()
  {
    return this.studentForm.get('emergencyContact').get('number') 
  }

  get dob()
  {
    return this.studentForm.get('dob') 
  }
  get firstLanguage()
  {
    return this.studentForm.get('firstLanguage') 
  }
  get placeofBirth()
  {
    return this.studentForm.get('placeofBirth') 
  }

  get city()
  {
    return this.studentForm.get('address').get('city')
  }
  get state()
  {
    return this.studentForm.get('address').get('state')
  }
  get country()
  {
    return this.studentForm.get('address').get('country')
  }
  get pincode()
  {
    return this.studentForm.get('address').get('pin')
  }

  get profession()
  {
    return this.studentForm.get('fatherInfo').get('profession')
  }
  get designation()
  {
    return this.studentForm.get('fatherInfo').get('designation')
  }
  get fatherPhone()
  {
    return this.studentForm.get('fatherInfo').get('phone')
  }
  get motherPhone()
  {
    return this.studentForm.get('motherInfo').get('phone')
  }

  addContact()
  {
    this.relation.push(this.fb.control('',Validators.required));
    this.number.push(this.fb.control(null,[Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$"),Validators.required]));
  }

  @Output() Student=new EventEmitter();

  onSubmit()
  {
    this.admissionStudent.push(this.studentForm.value);
    console.log(this.studentForm.value);
    console.table(this.admissionStudent);
    this.Student.emit(this.admissionStudent);
  }

  showTable()
  {
    this.tableStatus=!this.tableStatus;
  }

}
