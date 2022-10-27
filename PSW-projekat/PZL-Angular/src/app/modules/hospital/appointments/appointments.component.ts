import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Appointment } from '../model/appointment.model';
import { Router } from '@angular/router';
import { AppointmentService } from 'src/app/modules/hospital/services/appointment.service';


@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  public dataSource = new MatTableDataSource<Appointment>();
  displayedColumns: string[] = ['date', 'time', 'patientId'];
  public appointments: Appointment[] = [];

  //constructor() { }

  constructor(private appointmentService: AppointmentService, private router: Router) { }

  /*
  ngOnInit(): void {
    this.appointmentService.getAppointments().subscribe(res => {
      this.appointments = res;
      this.dataSource.data = this.appointments;
    })
  }
  */
  ngOnInit(): void{

  }
  public addAppointment() {
    this.router.navigate(['/appointments/addA']);
  }

}
