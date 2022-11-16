import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BloodRequest } from '../model/bloodRequest.model';
import { BloodResuestService } from 'src/app/modules/hospital/services/blood-request.service';
import { RequestState } from '../model/requestState';
import { ToastrService } from 'ngx-toastr';
import { BloodType } from '../model/bloodType';


@Component({
  selector: 'app-create-blood-request',
  templateUrl: './create-blood-request.component.html',
  styleUrls: ['./create-blood-request.component.css']
})
export class CreateBloodRequestComponent {

  public bloodRequest: BloodRequest = new BloodRequest(0, false, Date(), 1, '', '', RequestState.pending, '');
  public bloodTypes : BloodType[] = [BloodType.OMinus,BloodType.AMinus, BloodType.BMinus, BloodType.ABMinus, BloodType.OPlus, BloodType.APlus, BloodType.BPlus, BloodType.ABPlus];
  
    
  constructor(private bloodRequestService: BloodResuestService, private router: Router, private toastr: ToastrService) { }

  public createBloodRequest() {
    if (!this.isValidInput())
    {
      this.toastr.show("Fill in all fields correctly");
      return;
    }
    this.bloodRequestService.createBloodRequest(this.bloodRequest).subscribe(res => {
      this.router.navigate(['/appointments']);
    });
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

  private isValidInput(): boolean {
    return this.bloodRequest?.bloodQuantity.toString() != '' && this.bloodRequest?.bloodType.toString() != '' &&
     this.bloodRequest?.reason != '' && this.bloodRequest?.requiredForDate.toString() !='';
  }

}
