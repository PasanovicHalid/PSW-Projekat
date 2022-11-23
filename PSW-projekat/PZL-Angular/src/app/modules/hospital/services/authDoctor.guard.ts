import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthDoctorService } from './authDoctor.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardDoctor implements CanActivate {
  
  constructor(private authDoctorService: AuthDoctorService, private router: Router) { } 

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if(this.authDoctorService.isAuthenticated()){
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }

}
