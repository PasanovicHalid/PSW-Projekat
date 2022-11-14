import { Component, Injectable, OnInit } from '@angular/core';
import { AbstractControl, AsyncValidator, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, map, catchError, of } from 'rxjs';
import { AllergiesAndDoctorsForPatientRegistrationDto } from '../model/allergiesAndDoctorsForPatientRegistrationDto.model';
import { Allergy } from '../model/allergy.model';
import { DoctorForPatientRegistrationDto } from '../model/doctorForPatientRegistrationDto.model';
import { RegisterPatientDto, Gender, BloodType } from '../model/registerPatientDto.model';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public allergiesAndDoctors: AllergiesAndDoctorsForPatientRegistrationDto = new AllergiesAndDoctorsForPatientRegistrationDto();
  public registerForm: FormGroup | any;

  constructor(private registerService: RegisterService, private router: Router, private fb: FormBuilder, private usernameValidator: UniqueUsernameValidator) { }

  ngOnInit(): void {
    this.registerService.getAllergiesAndDoctors().subscribe(res => {
      this.allergiesAndDoctors = res;
    })
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(30)]],
      surname: ['', Validators.required],
      gender: [Gender, Validators.required],
      birthDate: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      street: ['', Validators.required],
      number: ['', Validators.required],
      city: ['', Validators.required],
      township: ['', Validators.required],
      postCode: ['', Validators.required],
      username: ['', [Validators.required, 
                    {
                      asyncValidators: this.usernameValidator.validate.bind(this.usernameValidator),
                      updateOn: 'blur'
                    }]],
      password: ['', Validators.required],
      bloodType: [BloodType, Validators.required],
      allergies: [Array<Allergy>],
      doctorName: [DoctorForPatientRegistrationDto, [Validators.required]]
    });
  }

  register(){
    let registerPatientDto: RegisterPatientDto = new RegisterPatientDto();
    registerPatientDto.name = this.registerForm.value.name;
    registerPatientDto.surname = this.registerForm.value.surname;
    registerPatientDto.gender = parseInt(this.registerForm.value.gender);
    registerPatientDto.birthDate = this.registerForm.value.birthDate;
    registerPatientDto.email = this.registerForm.value.email;
    registerPatientDto.street = this.registerForm.value.street;
    registerPatientDto.number = this.registerForm.value.number;
    registerPatientDto.city = this.registerForm.value.city;
    registerPatientDto.township = this.registerForm.value.township;
    registerPatientDto.postCode = this.registerForm.value.postCode;
    registerPatientDto.username = this.registerForm.value.username;
    registerPatientDto.password = this.registerForm.value.password;
    registerPatientDto.bloodType = parseInt(this.registerForm.value.bloodType);
    registerPatientDto.allergies = this.registerForm.value.allergies;
    registerPatientDto.doctorName = this.registerForm.value.doctorName;

    this.registerService.registerPatient(registerPatientDto).subscribe(res => {
      this.router.navigate(['/login']);
    });
  }
}

@Injectable({ providedIn: 'root' })
export class UniqueUsernameValidator implements AsyncValidator {
  constructor(private registerService: RegisterService) {}

  validate(
    control: AbstractControl
  ): Observable<ValidationErrors | null> {
    return this.registerService.isUsernameTaken(control.value).pipe(
      map(isTaken => (isTaken ? { uniqueUsername: true } : null)),
      catchError(() => of(null))
    );
  }
}
