import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../hospital/services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './homeManager.component.html',
  styleUrls: ['./homeManager.component.css']
})
export class HomeManagerComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit(): void {

  }

  logoutUser(){
    this.loginService.logout().subscribe(res => {
      
    })
  }
}
