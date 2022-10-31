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
       // console.log("nasli error")
        console.log(this.errorMessage)
      }
  }

  private toastError() {
    if (String(this.errorMessage).includes('EmailAlreadyExistsException')){
      this.toastr.error('Email is taken');
    }
  }


  private isValidInput(): boolean {
    var isValid = this.bloodBank?.name != '' && this.bloodBank.email != '' && this.bloodBank.serverAddress != '' && this.ValidateEmail() && this.validateServerAddress(); 
    if(isValid){
      return true;
    }else{
      this.toastr.show("Input is incorect");
      return false;
    }
  }
  private  ValidateEmail() 
{
 if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(this.bloodBank.email))
  {
    return (true)
  }
  this.toastr.show("Email is incorect");
    return (false)
}

private validateServerAddress(){
  var expression = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)?/gi;
var regex = new RegExp(expression);

if (this.bloodBank.serverAddress.match(regex)) {
  return(true);
} else {
  this.toastr.show("Server address is incorect");
  return false;
}
}
}
