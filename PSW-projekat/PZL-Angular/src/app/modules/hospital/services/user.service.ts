import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DoctorDto } from '../model/doctorDto';
import { PatientDto } from '../model/patientDto';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  GetAllPatients(): Observable<User[]> {
    return this.http.get<User[]>(this.apiHost + 'api/User/patient', {headers: this.headers});
  }

  GetAllDoctors(): Observable<User[]> {
    return this.http.get<User[]>(this.apiHost + 'api/User/doctor', {headers: this.headers});
  }
}
