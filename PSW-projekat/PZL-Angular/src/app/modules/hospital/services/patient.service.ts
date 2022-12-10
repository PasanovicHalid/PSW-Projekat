import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DoctorDto } from '../model/doctorDto';
import { Patient } from '../model/patient';
import { PatientDto } from '../model/patientDto';
import { User } from '../model/user';
import { MaliciousPatientDto } from '../model/maliciousPatientDto';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  GetPatientsNoTreatment(): Observable<PatientDto[]> {
    return this.http.get<PatientDto[]>(this.apiHost + 'api/patient/patientsNoTreatment', {headers: this.headers});
  }

  GetMaliciousPatients(): Observable<MaliciousPatientDto[]> {
    return this.http.get<MaliciousPatientDto[]>('api/privatepatient/', {headers: this.headers});
  }

  BlockPatient(id: any): Observable<any>{
    return this.http.put<any>('api/account/BlockUser/' + id,{headers: this.headers});
  }

  UnblockPatient(id: any): Observable<any>{
    return this.http.put<any>('api/account/UnblockUser/' + id,{headers: this.headers});
  }
}
