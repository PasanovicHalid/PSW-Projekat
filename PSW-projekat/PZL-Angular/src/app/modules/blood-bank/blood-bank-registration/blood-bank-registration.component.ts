import { Component } from '@angular/core';
import { BloodBankService } from '../services/blood-bank.service';
import { Router } from '@angular/router';
import { BloodBank } from '../model/blood-bank.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-blood-bank-registration',
  templateUrl: './blood-bank-registration.component.html',
  styleUrls: ['./blood-bank-registration.component.css']
})
export class BloodBankRegistrationComponent  {

  public bloodBank : BloodBank = new BloodBank();
  public errorMessage: any;

  constructor(private bloodBankService: BloodBankService, private router: Router, private toastr: ToastrService){}
  
  public registerBloodBank(){
    console.log(this.bloodBank);
    if (!this.isValidInput()) return;
    this.bloodBank.id=0;
    this.bloodBank.apiKey="apikey";
    this.bloodBank.password="pass";
    console.log(this.bloodBank);
    this.bloodBankService.registerBloodBank(this.bloodBank).subscribe(res => {
      this.router.navigate(['/blood-banks']);
    }, (error) => {
      this.errorMessage = error;
      this.toastError();
    });
      if (this.errorMessage !== '') {
        console.log("nasli error")
        console.log(this.errorMessage)
      }
  }

  private toastError() {
    if (String(this.errorMessage).includes('EmailAlreadyExistsException')){
      this.toastr.error('Email is taken');
    }
  }


  private isValidInput(): boolean {
    var isValid = this.bloodBank?.name != '' && this.bloodBank.email != '' && this.bloodBank.serverAddress != ''; 
    if(isValid){
      return true;
    }else{
      console.log("Incorrect input");
      return false;
    }
  }
}
