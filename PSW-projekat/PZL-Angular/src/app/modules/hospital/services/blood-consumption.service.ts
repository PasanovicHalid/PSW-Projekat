import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BloodConsumptionService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }


  createBloodConsumption(bloodConsumption: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/BloodConsumption', bloodConsumption, {headers: this.headers});
  }


}
