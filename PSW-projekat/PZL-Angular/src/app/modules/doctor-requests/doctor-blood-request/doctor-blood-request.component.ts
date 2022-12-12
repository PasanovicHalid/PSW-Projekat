import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BloodBank } from '../../blood-banks/model/blood-bank.model';
import { BloodType } from '../model/blood-type';
import { Doctor } from '../model/doctor';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { RequestState } from '../model/request-state';
import { BloodRequestService } from '../services/blood-request.service';
import { BloodBankService } from '../../blood-banks/services/blood-bank.service';
import { ToastrService } from 'ngx-toastr';
import { BloodRequest } from '../../blood-banks/model/blood-request.model';

@Component({
  selector: 'app-doctor-blood-request',
  templateUrl: './doctor-blood-request.component.html',
  styleUrls: ['./doctor-blood-request.component.css']
})
export class DoctorBloodRequestComponent implements OnInit {

  public request: DoctorBloodRequest;
  public errorMessage: any;
  public returnBack : boolean = false;
  public isBankOptionVisible: boolean = false;
  public canOrder: boolean = false;
  public isLoading: boolean = false;
  bloodBanks : BloodBank[] = [];

  constructor(private bloodRequestService: BloodRequestService, private router: Router, private route: ActivatedRoute,
            private bloodBankService: BloodBankService, private toastr: ToastrService) { }

  ngOnInit(): void {
    if(localStorage.getItem("currentUserRole") == 'Manager'){
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
    else{
      this.router.navigate(['/forbidden-access']);
    }  
  }

  getBloodByValue(value: number) {
    return Object.values(BloodType)[value]
  }

  getStateByValue(value: number) {
    return Object.values(RequestState)[value]
  }

  accept() {
    this.isBankOptionVisible = true;
    // this.bloodRequestService.acceptRequest(this.request.id).subscribe(res => {
    //   this.router.navigate(['/doctor-blood-requests']);})
    this.bloodBankService.getBloodBanks().subscribe(res =>{
      this.bloodBanks = res;
    });
  }

  decline() {
    this.bloodRequestService.declineRequest(this.request.id).subscribe(res => {
      this.router.navigate(['/doctor-blood-requests']);})
  }

  sendBack() {
    this.bloodRequestService.sendBackRequest(this.request.id, this.request.comment).subscribe(res => {
      this.router.navigate(['/doctor-blood-requests']);})
  }

  sendRequest(){
    this.bloodRequestService.acceptRequest(this.request).subscribe(res => {
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

  checkIfBankHasBlood(){
    this.canOrder = false;
    this.isLoading = true;
    var req = this.convertToBloodRequest()
    this.bloodBankService.sendBloodRequest(req).subscribe(res => {

      if(res == true){
        this.toastr.success("Bank currently has wanted blood type!");
        this.canOrder = true;
      }
      else{
        this.toastr.info("Bank currently has no wanted blood type!");
      }
      this.isLoading = false;
      
    }, (error) => {
      this.errorMessage = error;
      this.toastError();
      this.isLoading = false;
    });
  }

  convertToBloodRequest(){
    var request = new BloodRequest({bloodType : this.getBloodType(), bloodQuantity: this.request.bloodQuantity, bloodBankId: this.request.bloodBankId})
    return request;
  }

  getBloodType(){
    switch(this.request.bloodType){
      case BloodType.ON: return 'Ominus';
      case BloodType.AN: return 'Aminus';
      case BloodType.BN: return 'Bminus';
      case BloodType.ABN: return 'ABminus';
      case BloodType.OP: return 'Oplus';
      case BloodType.AP: return 'Aplus';
      case BloodType.BP: return 'Bplus';
      case BloodType.ABP: return 'Aplus';
      default: return 0; 
    }
  }

  private windowRefresh() {
    window.location.reload();
  }

  private toastError() {
    if (String(this.errorMessage).includes('FailedValidationException')){
      this.toastr.error('Sent values can\'t be processed');
    }
    else if (String(this.errorMessage).includes('401')){
      this.toastr.error('IPA key is invalid!');
    }
    else if (String(this.errorMessage).includes('404')){
      this.toastr.error('Bank not found on server side!');
    }
    else {
      this.toastr.error('Can\'t connect to blood bank server!');
    }
  }
  
}
