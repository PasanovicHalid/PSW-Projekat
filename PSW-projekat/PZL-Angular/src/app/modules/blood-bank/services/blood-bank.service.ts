import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Observable, catchError, throwError } from 'rxjs';
import { BloodBank } from '../model/blood-bank.model';
import { BloodRequest } from '../model/blood-request.model';

@Injectable({
  providedIn: 'root'
})
export class BloodBankService {

  apiHost: string = "http://localhost:45488/";
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getBloodBanks(): Observable<BloodBank[]> {
    // console.log(this.http.get<BloodBank[]>(this.apiHost + 'api/BloodBanks', {headers: this.headers}).pipe(catchError(this.handleError)));
    return this.http.get<BloodBank[]>(this.apiHost + 'api/BloodBanks', {headers: this.headers}).pipe(catchError(this.handleError));
  }
  
  registerBloodBank(bloodBank: any): Observable<any>{
    return this.http.post<any>(this.apiHost + 'api/BloodBanks', bloodBank, {headers: this.headers})
  }

  sendBloodRequest(bloodRequest: any): Observable<any>{
    return this.http.get<any>(this.apiHost + 'api/BloodBanks/' + bloodRequest.bloodBankID + '/' + bloodRequest.bloodType + '/' + bloodRequest.quantity, {headers: this.headers}).pipe(catchError(this.handleBloodRequestErrors));
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
  private handleBloodRequestErrors(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.status == 0) {
      // A client-side or network error ocured. Handle it acordingly.
      console.error('An error occured: ', error.error);

    } else if(error.status == 404)
    {
      // A client-side or network error ocured. Handle it acordingly.
      console.error('Sent object or parameters aren\'t valid: ', error.error);
      alert("Sent object or parameters aren\'t valid")
    }
    else if(error.status == 400){
      // A client-side or network error ocured. Handle it acordingly.
      console.error('Bood bank server is inactive: ', error.error);
      alert("Blood bank server is inactive.Please, try again later.")
      
    }
    else{
      console.error(`Backend returned code ${error.status}, body was: `, error.error);
      errorMessage = `Backend returned code ${error.status}, body was: `, error.error;
    
    }
    //Return an observable with user-facing error message.
    errorMessage += 'Something bad happened; please try again later.';
    return throwError(() => new Error(errorMessage))
  }

}
