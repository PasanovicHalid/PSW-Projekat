import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterPatientDto } from '../model/registerPatientDto.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getLoggedUser(): Observable<any> {
    return this.http.get<any>('api/Person/userInfo/' + localStorage.getItem("currentUserId"), {headers: this.headers});
  }

  getLoggedPatient(): Observable<RegisterPatientDto>{
    return this.http.get<RegisterPatientDto>('api/Patient/GetByPersonId/' + localStorage.getItem("currentUserId"), {headers: this.headers});
  }
}
