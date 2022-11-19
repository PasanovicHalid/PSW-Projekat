import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUserDto } from '../model/loginUserDto.model';
import { LoginService } from '../services/login.service';
import jwt_decode from 'jwt-decode';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup | any;
  public credentialsMissmach:boolean = false;


  constructor(private loginService: LoginService, private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required,Validators.minLength(3)]],
      password: ['', [Validators.required,Validators.minLength(3)]],
    });
  }

  login(){

    let LoginDto = new LoginUserDto();
    LoginDto.username = this.loginForm.value.username;
    LoginDto.password = this.loginForm.value.password;
    this.loginService.login(LoginDto ).subscribe(res => {
      this.router.navigate(['']);

      const tokenInfo = this.getDecodedAccessToken(res.token); // decode token
      localStorage.setItem('currentUser', res.token);
      localStorage.setItem('currentUserRole', tokenInfo.Role);
      localStorage.setItem('currentUserId', tokenInfo.Id);
      //console.log(localStorage.getItem("currentUserId"))
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
