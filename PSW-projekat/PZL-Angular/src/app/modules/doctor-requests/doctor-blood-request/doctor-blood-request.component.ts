import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BloodType } from '../model/blood-type';
import { Doctor } from '../model/doctor';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { RequestState } from '../model/request-state';
import { BloodRequestService } from '../services/blood-request.service';

@Component({
  selector: 'app-doctor-blood-request',
  templateUrl: './doctor-blood-request.component.html',
  styleUrls: ['./doctor-blood-request.component.css']
})
export class DoctorBloodRequestComponent implements OnInit {

  public request: DoctorBloodRequest;
  public errorMessage: any;
  public returnBack : boolean = false;

  constructor(private bloodRequestService: BloodRequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      let id : any = this.route.snapshot.paramMap.get('id') ;
      this.bloodRequestService.getBloodRequest(parseFloat(id)).subscribe(request => {
        this.bloodRequestService.getDoctors().subscribe(doctors => {
          this.request = new DoctorBloodRequest();
          this.request.combineWithBloodRequest(request);
          this.request = this.findDoctorForRequest(doctors, this.request, request.doctorId)
        }, (error) => {
          this.errorMessage = error;
        })
  
      }, (error) => {
          this.errorMessage = error;
      })
    } , (error) => {
      this.errorMessage = error;
    })
  }

  getBloodByValue(value: number) {
    return Object.values(BloodType)[value]
  }

  getStateByValue(value: number) {
    return Object.values(RequestState)[value]
  }

  accept() {
    this.bloodRequestService.acceptRequest(this.request.id).subscribe(res => {
      this.router.navigate(['/doctor-blood-requests']);})
  }

  decline() {
    this.bloodRequestService.declineRequest(this.request.id).subscribe(res => {
      this.router.navigate(['/doctor-blood-requests']);})
  }

  sendBack() {
    this.bloodRequestService.sendBackRequest(this.request.id, this.request.comment).subscribe(res => {
      this.router.navigate(['/doctor-blood-requests']);})
  }

  findDoctorForRequest(doctors: Doctor[], request: DoctorBloodRequest, doctorId : number) : DoctorBloodRequest{
    for (let doctor of doctors) {
      if(doctor.id == doctorId){
        request.doctor = doctor;
        break;
      }
    }
    return request;
  }

}
