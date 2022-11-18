import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';


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
      username: ['', [Validators.required,Validators.minLength(6)]],
      password: ['', [Validators.required,Validators.minLength(6)]],
    });
  }

  login(){
    this.loginService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe(res => {
      this.router.navigate(['']);
    },
    (err) => {
      if(err.error == "Username or password is incorrect.")
        this.credentialsMissmach = true;
    });
  }
}