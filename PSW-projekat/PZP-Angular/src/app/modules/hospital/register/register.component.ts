import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AllergiesAndDoctorsForPatientRegistrationDto } from '../model/allergiesAndDoctorsForPatientRegistrationDto.model';
import { RegisterPatientDto } from '../model/registerPatientDto.model';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public allergiesAndDoctors: AllergiesAndDoctorsForPatientRegistrationDto = new AllergiesAndDoctorsForPatientRegistrationDto();
  public registerPatientDto: RegisterPatientDto = new RegisterPatientDto();

  constructor(private registerService: RegisterService, private router: Router) { }

  ngOnInit(): void {
    this.registerService.getAllergiesAndDoctors().subscribe(res => {
      this.allergiesAndDoctors = res;
    })
  }

  register(event:any){
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }
    form.classList.add('was-validated');

    if (form.checkValidity() === true){
      this.registerService.registerPatient(this.registerPatientDto).subscribe(res => {
        this.router.navigate(['/login']);
      });
    }
  }
}
