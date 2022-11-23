import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthDoctorService {

    isAuthenticated(): boolean{
      return localStorage.getItem('currentUserRole') == 'Doctor';
    }
}
