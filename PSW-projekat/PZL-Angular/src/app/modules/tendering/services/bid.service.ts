import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Bid } from '../model/bid.model';

@Injectable({
    providedIn: 'root'
  })
  export class BidService {
    
  
    apiHost: string = "http://localhost:5000/";
    headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});
  
    constructor(private http: HttpClient) { }

    getBidsForTender(id:number):Observable<any>{
        return this.http.get<any>(this.apiHost + 'api/Bid/Tender/' + id, {headers: this.headers}).pipe(catchError(this.handleError));
    }

    createBid(bid: Bid): Observable<any>{
        return this.http.post<any>(this.apiHost + 'api/Bid', bid, {headers: this.headers}).pipe(catchError(this.handleError));
    }
    

    private handleError(error: HttpErrorResponse) {
        // console.log(new Error(error.status +'\n'+ error.error).message)
        return throwError(() => new Error(error.status +'\n'+ error.error))
    }

    
  }