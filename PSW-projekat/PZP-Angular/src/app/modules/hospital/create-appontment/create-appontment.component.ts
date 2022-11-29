import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create-appontment',
  templateUrl: './create-appontment.component.html',
  styleUrls: ['./create-appontment.component.css']
})
export class CreateAppontment implements OnInit{

  public fromDate = '';
  public toDate = '';
  public fromTime = '';
  public toTime = '';
  public prefer = 'doctor';

  constructor(private router: Router) { }

  ngOnInit(): void {

  }

  test(){
    console.log(this.fromDate);
    console.log(this.toDate);
    console.log(this.fromTime);
    console.log(this.toTime);
    console.log(this.prefer);
  }
}

