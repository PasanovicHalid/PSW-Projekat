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
    return this.http.get<BloodBank[]>(this.apiHost + 'api/BloodBanks', {headers: this.headers}).pipe(catchError(this.handleError));
  }
  
  registerBloodBank(bloodBank: any): Observable<any>{
    return this.http.post<any>(this.apiHost + 'api/BloodBanks', bloodBank, {headers: this.headers}).pipe(catchError(this.handleError));
  }
  
  checkBankExist(passKey: String):Observable<any> {
    console.log(this.apiHost + 'api/BloodBanks/reset/' + passKey);
    return this.http.get<any>(this.apiHost + 'api/BloodBanks/reset/' + passKey, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  changePassword(newPassword: any, passKey: any): Observable<any>{
    console.log(this.apiHost + 'api/BloodBanks/reset/' + passKey);
   return this.http.put<any>(this.apiHost + 'api/BloodBanks/reset/' + passKey, newPassword, {headers: this.headers}); 
  }

  sendBloodRequest(bloodRequest: any): Observable<any>{
    return this.http.get<any>(this.apiHost + 'api/BloodBanks/' + bloodRequest.bloodBankId + '/' + bloodRequest.bloodType + '/' + bloodRequest.bloodQuantity, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    // console.log(new Error(error.status +'\n'+ error.error).message)
    return throwError(() => new Error(error.status +'\n'+ error.error))
  }
}
