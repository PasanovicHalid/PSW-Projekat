import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Appointment } from '../model/appointment.model';
import { Doctor } from '../model/doctor1';
import { PatientDto } from '../model/patient';
import { Patient } from '../model/patient1';
import { Person } from '../model/person';
import { User } from '../model/user';
import { AppointmentService } from '../services/appointment.service';

@Component({
  selector: 'app-update-appointment',
  templateUrl: './update-appointment.component.html',
  styleUrls: ['./update-appointment.component.css']
})
export class UpdateAppointmentComponent implements OnInit {

  public appointment: Appointment = new Appointment(0, false, '', '', Date());
  public newPatient1: PatientDto = new PatientDto(0, '','','','', 0);
  public odgovor: Response;
  public pacijent: Patient = new Patient(0,0,0, Person, Doctor);
  

  constructor(private appointmentService: AppointmentService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.appointmentService.getAppointment(params['id']).subscribe(res => {
/*
        console.log(res);
        this.newPatient1 = new PatientDto(res.patient.id, res.patient.name, res.patient.surname, res.patient.email, res.patient.username, res.patient.role);
        console.log(this.newPatient1);
        this.appointment = res;
        */

        let result = Object.values(JSON.parse(JSON.stringify(res)));
        var app = new Appointment(res.id, res.deleted, res.patient, res.doctor, res.dateTime);
        var pp = new PatientDto(app.patient.id, app.patient.name, app.patient.surname, app.patient.email, app.patient.username, app.patient.role);

          this.newPatient1 = pp;
          console.log(app);
          console.log(app.patient);
          console.log(pp);
          this.appointment = app;

      })
    });
  }

  public updateAppointment(): void {
    if (!this.isValidInput()) return;
    this.appointmentService.updateAppointment(this.appointment).subscribe(res => {
      this.router.navigate(['/appointments']);
    });
  }

  private isValidInput(): boolean {
    return this.appointment?.dateTime.toString() != '';
  }

}
