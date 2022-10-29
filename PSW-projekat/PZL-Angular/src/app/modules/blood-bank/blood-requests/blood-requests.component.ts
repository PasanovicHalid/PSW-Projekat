import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import { BloodRequest } from 'src/app/modules/hospital/model/blood-request.model';
import { BloodBankService } from 'src/app/modules/blood-bank/services/blood-bank.service';

@Component({
  selector: 'app-blood-requests',
  templateUrl: './blood-requests.component.html',
  styleUrls: ['./blood-requests.component.css']
})
export class BloodRequestsComponent implements OnInit {

  private bloodBankID : string = '';
  private bloodType: string = '';
  private quantity: number = 0.0;

  constructor(private bloodBankService: BloodBankService, private router: Router) { }

  ngOnInit(): void {
  }

  public sendRequest() {
    if (!this.isValidInput()) return;
    console.log("ok")
    // this.bloodRequestService.sendRequest(this.bloodRequest).subscribe(res => {
    //   this.router.navigate(['/home']);
    // });
  }

  private isValidInput(): boolean {
    return true;
  }

}
