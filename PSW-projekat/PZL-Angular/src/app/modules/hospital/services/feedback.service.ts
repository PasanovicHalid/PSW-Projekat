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
    return this.http.get<FeedbackDto[]>(this.apiHost + 'api/feedbacks', {headers: this.headers});
  }
}
