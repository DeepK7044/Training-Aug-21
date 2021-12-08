import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormArray, Validators} from '@angular/forms';


@Component({
  selector: 'app-profile-editor',
  templateUrl: './profile-editor.component.html',
  styleUrls: ['./profile-editor.component.css']
})
export class ProfileEditorComponent implements OnInit {

  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
  }

  profileForm= this.fb.group({
    firstName:[''],
    lastName:[''],
    address:this.fb.group({
      street:[''],
      city:[''],
      state:[''],
      zip:['']
    }),
    aliases:this.fb.array([
      this.fb.control('')      
    ])
  });

  get aliases()
  {
    return this.profileForm.get('aliases') as FormArray;
  }

  addAlias()
  {
    this.aliases.push(this.fb.control(''));
  }

  onSubmit()
  {
    console.log(this.profileForm.value);
  }

  updateProfile() {
    this.profileForm.patchValue({
      firstName: 'Deep',
      address: {
        street: '123 Drew Street'
      }
    });
  }

}
