import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { PatientAppointment } from '../model/patientAppointmentsDto.model';
import { AppointmentsService } from '../services/appointments.service';

@Component({
  selector: 'app-patient-appointments',
  templateUrl: './patient-appointments.component.html',
  styleUrls: ['./patient-appointments.component.css']
})
export class PatientAppointmentsComponent implements OnInit {

  public dataSource = new MatTableDataSource<PatientAppointment>();
  displayedColumns: string[] = ['AppointmentTime', 'Doctor', 'Status'];
  public appointments: PatientAppointment[] = [];

  constructor(private appointmentService: AppointmentsService, private router: Router) { }

  ngOnInit(): void {
    this.appointmentService.getAppointmentsForPatient(9).subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
          this.appointments = []
          result.forEach((element: any) => {

            var app = new PatientAppointment(element.appointmentId, element.doctorFullName, element.appointmentTime, element.appointmentStatus);
            this.appointments.push(app);
          });
          this.dataSource.data = this.appointments;
    })
  }

  public cancellAppointment(id : number){

  }

}
