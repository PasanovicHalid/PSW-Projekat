import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { BloodType } from '../model/blood-type';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { RequestState } from '../model/request-state';
import { BloodRequestService } from '../services/blood-request.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-returned-requests-for-doctor',
  templateUrl: './returned-requests-for-doctor.component.html',
  styleUrls: ['./returned-requests-for-doctor.component.css']
})
export class ReturnedRequestsForDoctorComponent implements OnInit {

  public dataSource = new MatTableDataSource<DoctorBloodRequest>();
  public displayedColumns = ['Required Until', 'Quantity', 'Blood Type', 'Reason', 'Comment', 'Status'];
  public requests: DoctorBloodRequest[] = [];
  public errorMessage: any;
  private routeSub: Subscription;

  constructor(private bloodRequestService: BloodRequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.getDoctorsRequests(params['id']);
      localStorage.setItem("doctorID",params['id'] );
    });
    
  }

  public getDoctorsRequests(id: number){
    this.bloodRequestService.getReturnedRequestsForDoctor(id).subscribe(res => {
        this.dataSource.data = res;
      }, (error) => {
        this.errorMessage = error;
      });
  }
  public chooseBloodRequest(id:number){
    this.router.navigate(['/update-request', id]);
  }

  getBloodByValue(value: number) {
    return Object.values(BloodType)[value]
  }

  getStateByValue(value: number) {
    return Object.values(RequestState)[value]
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
