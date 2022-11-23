import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BloodType } from '../model/blood-type';
import { DoctorBloodRequest } from '../model/doctor-blood-request';
import { RequestState } from '../model/request-state';
import { BloodRequestService } from '../services/blood-request.service';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-update-request-for-doctor',
  templateUrl: './update-request-for-doctor.component.html',
  styleUrls: ['./update-request-for-doctor.component.css']
})
export class UpdateRequestForDoctorComponent implements OnInit {

  public request: DoctorBloodRequest = new DoctorBloodRequest();
  public errorMessage: any;
  public returnBack : boolean = false;
  private routeSub: Subscription;
  public date: string = '';
  public bloodTypes : BloodType[] = [BloodType.ON,BloodType.AN, BloodType.BN, BloodType.ABN, BloodType.OP, BloodType.AP, BloodType.BP, BloodType.ABP];

  constructor(private bloodRequestService: BloodRequestService, public datepipe: DatePipe, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    if(localStorage.getItem("currentUserRole") == 'Doctor'){
      this.routeSub = this.route.params.subscribe(params => {
        this.getRequest(params['id']);
      }, (error) => {
        this.errorMessage = error;
      });
    }
    else{
      this.router.navigate(['/forbidden-access']);
    }  
  }

  public getRequest(id: number){
    this.bloodRequestService.getBloodRequest(id).subscribe(res => {
        this.request = res;
        this.date = this.datepipe.transform(this.request.requiredForDate, 'MM-dd-yyyy')!;
        
      }, (error) => {
        this.errorMessage = error;
      });
  }
  getBloodByValue(value: number) {
    return Object.values(BloodType)[value]
  }

  getStateByValue(value: number) {
    return Object.values(RequestState)[value]
  }

  send() {
    if(this.validate()){
      this.bloodRequestService.updateRequestFromDoctor(this.request).subscribe(res => {
        this.router.navigate(['/returned-requests']);
      });
    }
    else{
      alert("You have to fill all fields!");
    }
    
  }

  validate(){
    if((this.request.bloodQuantity <= 0 || this.request.bloodQuantity > 10) || this.request.reason == ""
      || this.request.bloodType.toString() == "" || this.request.requiredForDate.toString() == ""){
        return false;
    }
    return true;
  }

  public ConvertToString(obj: BloodType): String{
    switch(obj){
      case 0: return 'ON';
      case 1: return 'AN';
      case 2: return 'BN';
      case 3: return 'ABN';
      case 4: return 'OP';
      case 5: return 'AP';
      case 6: return 'BP';
      case 7: return 'ABP';
      default: return '333'; 
    }
  }
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
