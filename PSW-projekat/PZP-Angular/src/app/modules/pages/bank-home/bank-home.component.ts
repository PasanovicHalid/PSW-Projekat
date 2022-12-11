import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../hospital/services/login.service';

@Component({
  selector: 'app-bank-home',
  templateUrl: './bank-home.component.html',
  styleUrls: ['./bank-home.component.css']
})
export class BankHomeComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {

  }

  logout(){
    this.loginService.logout().subscribe(res => {
      
    }) 
  }

}
