import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { BloodRequestService } from '../services/blood-request.service';

@Component({
  selector: 'app-doctor-blood-request',
  templateUrl: './doctor-blood-request.component.html',
  styleUrls: ['./doctor-blood-request.component.css']
})
export class DoctorBloodRequestComponent implements OnInit {

  public request: DoctorBloodRequest;
  public errorMessage: any;

  constructor(private bloodRequestService: BloodRequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // this.route.paramMap.subscribe(paramMap => {
    //   let id : string = this.route.snapshot.paramMap.get('id') ;
    //   this.bloodRequestService.getBloodRequest(id.).subscribe(request => {
    //     this.bloodRequestService.getDoctor(request.doctorId).subscribe(doctor => {
    //       this.request = new DoctorBloodRequest();
    //       this.request.combineWithBloodRequest(request);
    //       this.request.doctor = doctor;
    //     }, (error) => {
    //       this.errorMessage = error;
    //     })
  
    //   }, (error) => {
    //       this.errorMessage = error;
    //   })
    // } , (error) => {
    //   this.errorMessage = error;
    // })
  }

}
