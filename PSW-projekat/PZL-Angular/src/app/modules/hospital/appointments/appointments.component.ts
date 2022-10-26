import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Appointment } from '../model/appointment.model';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  public dataSource = new MatTableDataSource<Appointment>();
  displayedColumns: string[] = ['date', 'time', 'patientId'];
  public appointments: Appointment[] = [];
  constructor() { }

  ngOnInit(): void {
  }

}
