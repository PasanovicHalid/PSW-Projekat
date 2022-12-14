import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DoctorDto } from '../model/doctorDto';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getDoctorByPersonId(personId: number): Observable<DoctorDto> {
    return this.http.get<DoctorDto>(this.apiHost + 'api/doctor/doctorDto/' + personId, {headers: this.headers});
  }
}
