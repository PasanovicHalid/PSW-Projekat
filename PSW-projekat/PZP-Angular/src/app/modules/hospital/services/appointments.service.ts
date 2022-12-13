import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PatientAppointment } from '../model/patientAppointmentsDto.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getAppointmentsForPatient(personId: number): Observable<any> {
    return this.http.get<PatientAppointment[]>('api/publicAppointment/GetPatientAppointments/' + personId, {headers: this.headers});
  }

  cancelAppointment(appointmentId: number): Observable<any> {
    return this.http.put<Observable<any>>('api/publicAppointment/CancelAppointment/' + appointmentId, {headers: this.headers});
  }
}
