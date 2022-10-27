import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BloodRequest } from 'src/app/modules/hospital/model/blood-request.model';
import { BloodRequestService } from 'src/app/modules/hospital/services/blood-request.service';



@Component({
  selector: 'app-blood-requests',
  templateUrl: './blood-requests.component.html',
  styleUrls: ['./blood-requests.component.css']
})
export class BloodRequestsComponent implements OnInit {

  ngOnInit(): void {
  }
  public bloodRequest: BloodRequest = new BloodRequest();

  constructor(private bloodRequestService: BloodRequestService, private router: Router) { }

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
