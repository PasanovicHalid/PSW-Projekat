import { Component, OnInit } from '@angular/core';
import { BloodBank } from '../model/blood-bank.model';
import { BloodType } from '../model/blood-type';
import { EmergencyBloodRequest } from '../model/emergency-blood-request';
import { EmergencyBloodRequestService } from '../services/emergency-blood-request.service';

@Component({
  selector: 'app-request-blood',
  templateUrl: './request-blood.component.html',
  styleUrls: ['./request-blood.component.css']
})
export class RequestBloodComponent implements OnInit {

  public request : EmergencyBloodRequest = new EmergencyBloodRequest();
  public errorMessage: any;
  public bloodTypes : BloodType[] = [BloodType.ON,BloodType.AN, BloodType.BN, BloodType.ABN, BloodType.OP, BloodType.AP, BloodType.BP, BloodType.ABP];
  public bloodBanks : BloodBank[] = [];

  constructor(private emergencyService : EmergencyBloodRequestService) { }

  ngOnInit(): void {
    this.emergencyService.getBloodBanks().subscribe( res => {
      this.bloodBanks = res;
    },(error) => {
      this.errorMessage = error;
    })
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

  public accept() {
    this.emergencyService.askForBlood(this.request).subscribe( res => {
        this.emergencyService.updateBloodCount(this.request.bloodType, this.request.bloodQuantity).subscribe();
    },(error) => {
      this.errorMessage = error;
    })
  }

}
