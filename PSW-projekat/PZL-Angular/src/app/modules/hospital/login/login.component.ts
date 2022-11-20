import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { LoginUserDto } from "../model/loginUserDto.model";
import { LoginService } from "../services/login.service";
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public credentialsMissmach:boolean = false;
  public username: string;
  public password: string;

  constructor(private loginService: LoginService, private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.username = "pera";
    this.password = "123";
  }

  login(){
    let LoginDto = new LoginUserDto();
    LoginDto.username = this.username;
    LoginDto.password = this.password;
    console.log("Morate sami da hardkodujete ne mogu da resim sa ngModel jednostavno nece da odluci da radi: " + this.username + " - " + this.password)
    this.loginService.login(LoginDto ).subscribe(res => {

      const tokenInfo = this.getDecodedAccessToken(res.token); // decode token
      localStorage.setItem('currentUser', res.token);
      localStorage.setItem('currentUserRole', tokenInfo.Role);
      localStorage.setItem('currentUserId', tokenInfo.Id);
      
      if(localStorage.getItem('currentUserRole') == 'Manager')
        this.router.navigate(['/homeManager']);
      if(localStorage.getItem('currentUserRole') == 'Doctor')
        this.router.navigate(['/homeDoctor']);
    },
    (err) => {
      if(err.error == "Username or password is incorrect.")
        this.credentialsMissmach = true;
    });
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
}

