import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

    apiHost: string = 'http://localhost:16177/';
    headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    constructor(private http: HttpClient) { }

    isAuthenticated(username: string){
        const params = new HttpParams()
        .set('username', username)
        return this.http.post<any>(this.apiHost + 'api/Account/IsAuthenticated', username, { headers: this.headers})
    }
}
