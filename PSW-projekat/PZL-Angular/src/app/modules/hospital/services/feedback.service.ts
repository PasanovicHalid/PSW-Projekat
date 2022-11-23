import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FeedbackDto } from '../model/feedbackdto.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getFeedbacks(): Observable<FeedbackDto[]> {
    return this.http.get<FeedbackDto[]>('api/privatefeedbacks', {headers: this.headers});
  }

  approve(feedbackDto: any): Observable<any> {
    return this.http.put<any>('api/privatefeedbacks/approve', feedbackDto, {headers: this.headers});
  }
  
  reject(feedbackDto: any): Observable<any> {
    return this.http.put<any>('api/privatefeedbacks/reject', feedbackDto, {headers: this.headers});
  }
}
