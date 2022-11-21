import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ReportSettings } from '../model/report-settings';

@Injectable({
  providedIn: 'root'
})
export class ReportSettingsService {

  apiHost: string = "http://localhost:5000/";
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getReportSettings(): Observable<ReportSettings> {
    return this.http.get<ReportSettings>(this.apiHost + 'api/ReportSettings/setting', {headers: this.headers}).pipe(catchError(this.handleError));
  }

  updateSettings(settings: any) : Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/ReportSettings', settings, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(() => new Error(error.status +'\n'+ error.error))
  }
}
