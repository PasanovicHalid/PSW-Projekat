import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Blood } from '../model/blood';

@Injectable({
  providedIn: 'root'
})
export class BloodService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getBloods(): Observable<Blood[]> {
    return this.http.get<Blood[]>(this.apiHost + 'api/bloods', {headers: this.headers});
  }

  getBlood(id: number): Observable<Blood> {
    return this.http.get<Blood>(this.apiHost + 'api/bloods/' + id, {headers: this.headers});
  }

  deleteBlood(id: any): Observable<any> {
    return this.http.delete<any>(this.apiHost + 'api/bloods/' + id, {headers: this.headers});
  }

  createBlood(blood: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/bloods', blood, {headers: this.headers});
  }

  updateBlood(blood: any): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/bloods/' + blood.id, blood, {headers: this.headers});
  }

  updateQuantityBlood(blood: any, quantity: number): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/blood/bloods/' + blood.id + "/"+ quantity, blood, {headers: this.headers});
  }
}
