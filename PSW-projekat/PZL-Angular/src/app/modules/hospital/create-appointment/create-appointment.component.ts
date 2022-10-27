import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/modules/hospital/model/appointment.model';
import { AppointmentService } from 'src/app/modules/hospital/services/appointment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-appointment',
  templateUrl: './create-appointment.component.html',
  styleUrls: ['./create-appointment.component.css']
})
export class CreateAppointmentComponent implements OnInit {

  public appointment: Appointment = new Appointment();

  //constructor() { }
  constructor(private appointmentService: AppointmentService, private router: Router) { }

  public createAppointment() {
    if (!this.isValidInput()) return;
    this.appointmentService.createAppointment(this.appointment).subscribe(res => {
      this.router.navigate(['/appointments']);
    });
  }

  private isValidInput(): boolean {
    return this.appointment?.patientId != 0 && this.appointment?.date.toString() != '' && this.appointment?.time.toString() != '';
  }

  ngOnInit(): void {
  }

}
