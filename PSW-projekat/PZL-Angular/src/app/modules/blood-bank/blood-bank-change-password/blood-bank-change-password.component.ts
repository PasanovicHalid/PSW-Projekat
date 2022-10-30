import { Component, importProvidersFrom, OnInit } from '@angular/core';
import { BloodBank } from '../model/blood-bank.model';
import { BloodBankService } from '../services/blood-bank.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blood-bank-change-password',
  templateUrl: './blood-bank-change-password.component.html',
  styleUrls: ['./blood-bank-change-password.component.css']
})
export class BloodBankChangePasswordComponent implements OnInit {

  public bloodBank : BloodBank = new BloodBank();
  public newPassword: String = new String();
  public repeatedPassword: String = new String();

  constructor(private bloodBankService: BloodBankService, private router: Router) { }

  ngOnInit(): void {
  }

  public changePassword(){
    if(!this.isValidInput()) return;
    console.log(this.newPassword);
    console.log(this.repeatedPassword);
    this.bloodBankService.changePassword(this.newPassword).subscribe(res =>
      this.router.navigate(['/blood-banks']));
      console.log("zavrsili smo registraciju");

  }

  private isValidInput(): boolean {
    var isValid = this.newPassword == this.repeatedPassword && this.newPassword.length > 7; 
    if(isValid){
      return true;
    }else{
      console.log("Incorrect  ");
      return false;
    }
  }

}
