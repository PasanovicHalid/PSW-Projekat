import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUserDto } from '../model/loginUserDto.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiHost: string = 'http://localhost:16177/';
  integrationHost: string = 'http://localhost:5000/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  login(LoginDto: LoginUserDto): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/Account/Login', LoginDto, {headers: this.headers});
  }

  bankLogin(LoginDto: LoginUserDto): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/Account/LoginBank', LoginDto, {headers: this.headers});
  }

  logout(){
    localStorage.clear();
    return this.http.get<any>(this.apiHost + 'api/Account/Logout', {headers: this.headers});
  }
}
