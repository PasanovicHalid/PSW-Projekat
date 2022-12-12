import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckAvailableAppontmentDto } from '../model/checkAvailableAppointmentsDto.mode';
import { DoctorForCreatingAppointmentDto } from '../model/doctorForCreatingAppointmentDto.model';
import { AppointmentAvailableForCreatingAppointment } from '../model/appointmentAvailableForCreatingAppointment.mode';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getAllDoctorsForCreatingAppointment(): Observable<DoctorForCreatingAppointmentDto[]> {
    return this.http.get<DoctorForCreatingAppointmentDto[]>('api/publicAppointment/GetAllDoctorsForCreatingAppointment', {headers: this.headers});
  }

  getAllAvailableAppointmentsForCreatingAppointment(
    checkAvailableAppontment: CheckAvailableAppontmentDto
  ): Observable<AppointmentAvailableForCreatingAppointment[]> {
    return this.http.post<AppointmentAvailableForCreatingAppointment[]>(
      'api/publicAppointment/GetAllAvailableAppointmentsForCreatingAppointment', 
      checkAvailableAppontment,
      { headers: this.headers }
    );
  }

}
