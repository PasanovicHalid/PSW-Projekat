import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthManagerService } from './authManager.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardManager implements CanActivate {
  
  constructor(private authManagerService: AuthManagerService, private router: Router) { } 

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if(this.authManagerService.isAuthenticated()){
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }

}
