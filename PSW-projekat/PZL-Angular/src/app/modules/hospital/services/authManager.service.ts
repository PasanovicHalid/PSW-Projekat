import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthManagerService {

    isAuthenticated(): boolean{
      return localStorage.getItem('currentUserRole') == 'Manager';
    }
}
