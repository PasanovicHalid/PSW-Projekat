import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DoctorForPatientRegistrationDto } from '../model/doctorForPatientRegistrationDto.model';
import { Specialization } from '../model/scheduleAppointment.model';

@Component({
  selector: 'app-schedule-appointment',
  templateUrl: './schedule-appointment.component.html',
  styleUrls: ['./schedule-appointment.component.css']
})
export class ScheduleAppointmentComponent implements OnInit {

  public doctors: Array<DoctorForPatientRegistrationDto> = [];
  public freeAppointments: Array<number> = [];

  public appointmentForm: FormGroup | any;

  public currentStep: number = 0;
  public step: Array<string> = [];

  constructor(private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.step = ['initial', 'none', 'none', 'none', 'none'];
    this.appointmentForm = this.fb.group({
      date: [Date, [Validators.required]],
      specialization: [Specialization, [Validators.required]],
      doctor: [DoctorForPatientRegistrationDto, [Validators.required]],
      time: [Number, [Validators.required]]
    });
  }

  next():void{
    this.currentStep += 1;
    switch (this.currentStep) {
      case 0:
          this.step[0] = 'initial';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none';
          break;
      case 1:
          this.step[0] = 'none';
          this.step[1] = 'initial';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none'; 
          break;
      case 2:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'initial';
          this.step[3] = 'none';
          this.step[4] = 'none'; 
          break;
      case 3:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'initial';
          this.step[4] = 'none'; 
          break;
      case 4:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'initial';
          break;
      default:
          this.step[0] = 'initial';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none';
          break;
    }
  }

  previous():void{
    this.currentStep -= 1;
    switch (this.currentStep) {
      case 0:
          this.step[0] = 'initial';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none';
          break;
      case 1:
          this.step[0] = 'none';
          this.step[1] = 'initial';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none'; 
          break;
      case 2:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'initial';
          this.step[3] = 'none';
          this.step[4] = 'none'; 
          break;
      case 3:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'initial';
          this.step[4] = 'none'; 
          break;
      case 4:
          this.step[0] = 'none';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'initial';
          break;
      default:
          this.step[0] = 'initial';
          this.step[1] = 'none';
          this.step[2] = 'none';
          this.step[3] = 'none';
          this.step[4] = 'none';
          break;
    }
  }

}
