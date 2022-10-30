import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Observable, catchError, throwError } from 'rxjs';
import { BloodBank } from '../model/blood-bank.model';

@Injectable({
  providedIn: 'root'
})
export class BloodBankService {

  apiHost: string = "http://localhost:5000/";
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getBloodBanks(): Observable<BloodBank[]> {

    // console.log(this.http.get<BloodBank[]>(this.apiHost + 'api/BloodBanks', {headers: this.headers}).pipe(catchError(this.handleError)));
    return this.http.get<BloodBank[]>(this.apiHost + 'api/BloodBanks', {headers: this.headers}).pipe(catchError(this.handleError));
  }
  
  registerBloodBank(bloodBank: any): Observable<any>{
    return this.http.post<any>(this.apiHost + 'api/BloodBanks', bloodBank, {headers: this.headers})
  }
  
  changePassword(newPassword: any): Observable<any>{
    return this.http.post<any>(this.apiHost + 'api/BloodBanks', newPassword, {headers: this.headers})
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.status == 0) {
      // A client-side or network error ocured. Handle it acordingly.
      console.error('An error occured: ', error.error);

    } else {
      console.error(`Backend returned code ${error.status}, body was: `, error.error);
      errorMessage = `Backend returned code ${error.status}, body was: `, error.error;
    }
    //Return an observable with user-facing error message.
    errorMessage += 'Something bad happened; please try again later.';
    return throwError(() => new Error(errorMessage))
  }

}
