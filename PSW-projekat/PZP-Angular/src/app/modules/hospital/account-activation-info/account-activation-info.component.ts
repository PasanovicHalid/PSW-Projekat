import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-account-activation-info',
  templateUrl: './account-activation-info.component.html',
  styleUrls: ['./account-activation-info.component.css']
})
export class AccountActivationInfo{

  constructor(private router: Router) { }

  toLogin(){
    this.router.navigate(['/login']);
  }
}
