import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ScheduledRequest } from '../model/scheduled-order';

@Injectable({
  providedIn: 'root',
})
export class ScheduledRequestsService {
  integrationApiHost: string = 'http://localhost:5000/';
  headers: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  constructor(private http: HttpClient) {}

  createRequest(request: ScheduledRequest): Observable<any> {
    return this.http
      .post<any>(this.integrationApiHost + 'api/ScheduledOrder', request, {
        headers: this.headers,
      })
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(() => new Error(error.status + '\n' + error.error));
  }
}
