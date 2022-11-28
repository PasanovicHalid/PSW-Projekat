import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Tender } from '../model/tender.model';

@Injectable({
  providedIn: 'root'
})
export class TenderService {

  integrationApiHost: string = "http://localhost:5000/";
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getTenders(): Observable<Tender[]> {
    return this.http.get<Tender[]>(this.integrationApiHost + 'api/Tender', {headers: this.headers}).pipe(catchError(this.handleError))
  }
  getTender(id : number): Observable<Tender> {
    return this.http.get<Tender>(this.integrationApiHost + 'api/Tender/' + id, {headers: this.headers}).pipe(catchError(this.handleError))
  }
  private handleError(error: HttpErrorResponse) {
    return throwError(() => new Error(error.status +'\n'+ error.error))
  }
}
