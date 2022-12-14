import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckAvailableAppontmentDto } from '../model/checkAvailableAppointmentsDto.mode';
import { DoctorForCreatingAppointmentDto } from '../model/doctorForCreatingAppointmentDto.model';
import { AppointmentAvailableForCreatingAppointment } from '../model/appointmentAvailableForCreatingAppointment.mode';
import { ScheduleAppointment } from '../model/scheduleAppointment.model';
import { CustomAppointmentForCreatingDto } from '../model/customAppointmentForCreatingDto.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  scheduleAppointment(scheduleAppointment: ScheduleAppointment): Observable<ScheduleAppointment> {
    return this.http.post<ScheduleAppointment>('api/PublicAppointment/Schedule', scheduleAppointment, {headers: this.headers});
  }

  getAllDoctorsForCreatingAppointment(): Observable<DoctorForCreatingAppointmentDto[]> {
    return this.http.get<DoctorForCreatingAppointmentDto[]>('api/publicAppointment/GetAllDoctorsForCreatingAppointment', { headers: this.headers });
  }

  postAllAvailableAppointmentsForCreatingAppointment(
    checkAvailableAppontment: CheckAvailableAppontmentDto
  ): Observable<AppointmentAvailableForCreatingAppointment[]> {

    return this.http.post<AppointmentAvailableForCreatingAppointment[]>(
      'api/publicAppointment/GetAllAvailableAppointmentsForCreatingAppointment', 
      checkAvailableAppontment,
      { headers: this.headers }
    );

  }

  postCreateCustomAppointment(
    checkAppointment: CustomAppointmentForCreatingDto
  ): Observable<CustomAppointmentForCreatingDto[]> {

    return this.http.post<CustomAppointmentForCreatingDto[]>(
      'api/publicAppointment/CreateCustomAppointment', 
      checkAppointment,
      { headers: this.headers }
    );

  }

}
