import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PatientAppointment } from '../model/patientAppointmentsDto.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getAppointmentsForPatient(personId: number): Observable<any> {
    return this.http.get<PatientAppointment[]>(this.apiHost + 'api/publicAppointment/GetPatientAppointments/' + personId, {headers: this.headers});
  }
}
