import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  public feedbackCount = 0;

  constructor(private router: Router) { }

  ngOnInit(): void {

  }

  loginUser(){
    this.router.navigate(['/login']);
  }
}
