import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserInfoDto } from '../model/userInfoDto.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public token = localStorage.getItem("currentUser");
  public tokenString = '' + this.token;
  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': this.tokenString });

  constructor(private http: HttpClient) { }

  getLoggedUser(): Observable<any> {
    return this.http.get<any>(this.apiHost + 'api/Person/userInfo/' + localStorage.getItem("currentUserId"), {headers: this.headers});
  }
}
