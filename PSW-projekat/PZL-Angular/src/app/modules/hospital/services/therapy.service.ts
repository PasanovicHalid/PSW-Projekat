import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Treatment } from '../model/treatment';
import { Therapy } from '../model/therapy';

@Injectable({
  providedIn: 'root'
})
export class TherapyService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getTherapys(): Observable<Therapy[]> {
    return this.http.get<Therapy[]>(this.apiHost + 'api/therapys', {headers: this.headers});
  }

  getTherapy(id: number): Observable<Therapy> {
    return this.http.get<Therapy>(this.apiHost + 'api/therapy/' + id, {headers: this.headers});
  }

  deleteTherapy(id: any): Observable<any> {
    return this.http.delete<any>(this.apiHost + 'api/therapy/' + id, {headers: this.headers});
  }

  updateTherapy(therapy: any): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/therapy/' + therapy.id, therapy, {headers: this.headers});
  }

  createTherapy(therapy: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/therapy', therapy, {headers: this.headers});
  }
}
