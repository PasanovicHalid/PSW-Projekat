import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { RegisterService } from '../services/register.service';


@Component({
  selector: 'app-account-activation',
  templateUrl: './account-activation.component.html',
  styleUrls: ['./account-activation.component.css']
})
export class AccountActivationThanks implements OnInit{

  public username = "";
  public code = "";

  constructor(private router: Router, private route: ActivatedRoute, private registerService: RegisterService) { 
    this.route.queryParams.subscribe(params => {
      this.username = params['username'];
      this.code = params['code'];
    });
  }

  ngOnInit(): void {
    console.log("username= " + this.username)
    console.log("code= " + encodeURIComponent(this.code))
    this.registerService.sendAccountConfirmation(this.username, decodeURI(this.code).replace(/\ /g,"+")).subscribe(res => {
      this.router.navigate(['/login']);
    });
  }

}


