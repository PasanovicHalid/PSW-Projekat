import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DoctorForPatientRegistrationDto } from '../model/doctorForPatientRegistrationDto.model';
import { Specialization } from '../model/scheduleAppointment.model';
import { StepperOrientation } from '@angular/material/stepper';
import { Observable, map } from 'rxjs';
import { BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-schedule-appointment',
  templateUrl: './schedule-appointment.component.html',
  styleUrls: ['./schedule-appointment.component.css']
})
export class ScheduleAppointmentComponent implements OnInit {

  public doctors: Array<DoctorForPatientRegistrationDto> = [];
  public freeAppointments: Array<string> = [];

  public appointmentForm: FormGroup | any;

  public dateForm!: FormGroup;
  public specializationForm!: FormGroup;
  public doctorForm!: FormGroup;
  public timeForm!: FormGroup;

  stepperOrientation: Observable<StepperOrientation> | undefined;

  constructor(private router: Router, private fb: FormBuilder, private breakpointObserver: BreakpointObserver) { }

  ngOnInit(): void {
    this.stepperOrientation = this.breakpointObserver
    .observe('(min-width: 800px)')
    .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));

    this.dateForm = this.fb.group({
      date: [Date, [Validators.required]]
    });
    this.specializationForm = this.fb.group({
      specialization: [Specialization, [Validators.required]]
    });
    this.doctorForm = this.fb.group({
      doctor: [DoctorForPatientRegistrationDto, [Validators.required]]
    });
    this.timeForm  = this.fb.group({
      time: [Number, [Validators.required]]
    });
  }

  getDoctors(){
    this.doctors = [new DoctorForPatientRegistrationDto({id:0,fullName:'Marko Markovic'})]
  }

  getFreeAppointmentTimes(){
    this.freeAppointments = ['12:00', '12:20', '12:40']
  }
}
