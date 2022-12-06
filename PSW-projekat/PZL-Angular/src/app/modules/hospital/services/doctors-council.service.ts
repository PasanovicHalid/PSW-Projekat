import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DoctorsCouncilDto } from '../model/doctorsCouncilDto';

@Injectable({
  providedIn: 'root'
})
export class DoctorsCouncilService {

  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  createBloodRequest(doctorsCouncil: any): Observable<any> {
    return this.http.post<any>('api/CouncilOfDoctors', doctorsCouncil, {headers: this.headers});
  }

  GetAllCouncilByDoctor(doctorId: number) : Observable<any> {
    return this.http.get<DoctorsCouncilDto[]>('api/Doctor/doctor/' + doctorId, {headers: this.headers});
  }
}



