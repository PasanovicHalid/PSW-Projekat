import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BloodRequest } from '../model/blood-request.model';

@Injectable({
  providedIn: 'root'
})
export class BloodRequestService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  sendRequest(bloodRequest: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/bloodRequests', bloodRequest, {headers: this.headers});
  }
}
