import { AppointmentService } from './../services/appointment.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CheckAvailableAppontmentDto } from '../model/checkAvailableAppointmentsDto.mode';
import { AppointmentAvailableForCreatingAppointment } from '../model/appointmentAvailableForCreatingAppointment.mode';
import { DoctorForCreatingAppointmentDto } from '../model/doctorForCreatingAppointmentDto.model';

@Component({
  selector: 'app-create-appointment',
  templateUrl: './create-appointment.component.html',
  styleUrls: ['./create-appointment.component.css']
})
export class CreateAppointment implements OnInit{
  public fromDate = new Date();
  public toDate = new Date();
  public fromTime = new Date();
  public toTime = new Date();
  public prefer = 'doctor';
  public doctors: Array<DoctorForCreatingAppointmentDto> = [];
  public selectedDoctorID = 0;
  public availableAppointments: AppointmentAvailableForCreatingAppointment[] = [];

  public validatederror = false;

  constructor(private router: Router, private appointmentService: AppointmentService) { }

  ngOnInit(): void {
    this.appointmentService.getAllDoctorsForCreatingAppointment().subscribe(res => {
      this.doctors = res;
    })
  }

  test(){
    /*console.log(this.validatederror);

    console.log(this.fromDate);
    console.log(this.toDate);
    console.log(this.fromTime);
    console.log(this.toTime);
    console.log(this.prefer);
    console.log(this.selectedDoctorID);*/

    let checkAvailableAppontment = new CheckAvailableAppontmentDto(
      this.fromDate.toString(), 
      this.toDate.toString(), 
      this.fromTime.toString(),
      this.toTime.toString(),
      this.prefer,
      this.selectedDoctorID,
      Number(localStorage.getItem('currentUserId'))
    );

    this.appointmentService.getAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontment).subscribe(res => {
      this.availableAppointments = res;
    })
  }

  validate() {
    this.validatederror =  false;
    
    if(!(this.fromDate < this.toDate))
      this.validatederror = false;
    if(!(this.fromTime < this.toTime))
      this.validatederror = false;
    if(this.selectedDoctorID == 0 || this.selectedDoctorID > this.doctors.length)
      this.validatederror = false;
    if(!(this.prefer == 'doctor' || this.prefer == 'time'))
      this.validatederror = false;
  }
}

