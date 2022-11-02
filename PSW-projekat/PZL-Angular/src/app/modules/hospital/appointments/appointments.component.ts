import { MatTableDataSource } from '@angular/material/table';
import { Appointment } from '../model/appointment.model';
import { AppointmentService } from 'src/app/modules/hospital/services/appointment.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { User } from '../model/user';


@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  public dataSource = new MatTableDataSource<Appointment>();
  displayedColumns: string[] = ['dateTime', 'patientName', 'patientSurname'];
  public appointments: Appointment[] = [];
  public patient1: User = new User(0, '', '', 0);

  //constructor() { }

  constructor(private appointmentService: AppointmentService, private router: Router) { }

  
  ngOnInit(): void {
    this.appointmentService.GetAllByDoctor(3).subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Appointment(element.id, element.deleted, element.patinet, element.doctor, element.dateTime);
        this.patient1 = element.patinet;
        this.appointments.push(app);
      });
      this.dataSource.data = this.appointments;
    })
  }
  
  public addAppointment() {
    this.router.navigate(['/appointments/add']);
  }

}
