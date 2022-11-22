import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../hospital/services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './homePatient.component.html',
  styleUrls: ['./homePatient.component.css']
})
export class HomePatientComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {

  }

  logout(){
    this.loginService.logout().subscribe(res => {
      
    }) 
  }

}
