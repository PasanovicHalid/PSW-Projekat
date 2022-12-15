import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Feedback } from '../model/feedback.model';
import { FeedbackDto } from '../model/feedbackDto.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getFeedbacks(): Observable<Feedback[]> {
    return this.http.get<Feedback[]>('api/feedbacks', {headers: this.headers});
  }

  getFeedback(id: number): Observable<Feedback> {
    return this.http.get<Feedback>('api/feedbacks/' + id, {headers: this.headers});
  }

  deleteFeedback(id: any): Observable<any> {
    return this.http.delete<any>('api/feedbacks/' + id, {headers: this.headers});
  }

  createFeedback(feedback: any): Observable<any> {
    return this.http.post<any>('api/feedbacks', feedback, {headers: this.headers});
  }

  updateFeedback(feedback: any): Observable<any> {
    return this.http.put<any>('api/feedbacks/' + feedback.id, feedback, {headers: this.headers});
  }

  getAllFeedbackPublicDtos(): Observable<FeedbackDto[]> {
    return this.http.get<FeedbackDto[]>('api/feedbacks/public', {headers: this.headers});
  }
}
