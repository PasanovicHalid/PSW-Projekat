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
  displayedColumns: string[] = ['dateTime', 'patientName', 'patientSurname'];
  public appointments: Appointment[] = [];

  //constructor() { }

  constructor(private appointmentService: AppointmentService, private router: Router) { }

  
  ngOnInit(): void {
    this.appointmentService.GetAllByDoctor(3).subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Appointment(element.appointmentId, element.dateTime, element.patinet.name, element.patinet.surname);
        this.appointments.push(app);
      });
      this.dataSource.data = this.appointments;
    })
  }
  
  public addAppointment() {
    this.router.navigate(['/appointments/addA']);
  }

}
