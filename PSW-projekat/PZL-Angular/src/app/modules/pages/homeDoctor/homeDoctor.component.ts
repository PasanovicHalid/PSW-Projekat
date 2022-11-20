import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../hospital/services/login.service';

@Component({
  selector: 'app-home-doctor',
  templateUrl: './homeDoctor.component.html',
  styleUrls: ['./homeDoctor.component.css']
})
export class HomeDoctorComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit(): void {

  }

  logoutUser(){
    this.loginService.logout().subscribe(res => {
      
    })
  }
}
