import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleAppointment } from '../model/scheduleAppointment.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  scheduleAppointment(scheduleAppointment: ScheduleAppointment): Observable<ScheduleAppointment> {
    return this.http.post<ScheduleAppointment>(this.apiHost + 'api/PublicAppointment/Schedule', scheduleAppointment, {headers: this.headers});
  }
}
