import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { BloodRequestService } from '../services/blood-request.service';

@Component({
  selector: 'app-all-doctor-blood-requests',
  templateUrl: './all-doctor-blood-requests.component.html',
  styleUrls: ['./all-doctor-blood-requests.component.css']
})
export class AllDoctorBloodRequestsComponent implements OnInit {

  public dataSource = new MatTableDataSource<DoctorBloodRequest>();
  public displayedColumns = ['Required Until', 'Quantity', 'Blood Type', 'Reason', 'Doctor', 'Status'];
  public requests: DoctorBloodRequest[] = [];
  public errorMessage: any;

  constructor(private bloodRequestService: BloodRequestService, private router: Router) { }

  ngOnInit(): void {
    this.bloodRequestService.getBloodRequests().subscribe(requests => {
      this.bloodRequestService.getDoctors().subscribe(doctors => {
        this.requests = this.bloodRequestService.combineDoctorsWithRequests(requests, doctors);
        this.dataSource.data = this.requests;
      }, (error) => {
        this.errorMessage = error;
      })
    }, (error) => {
      this.errorMessage = error;
    })
  }

  public chooseBloodRequest(id:number){
    this.router.navigate(['doctor-blood-request', id]);
  }

}
