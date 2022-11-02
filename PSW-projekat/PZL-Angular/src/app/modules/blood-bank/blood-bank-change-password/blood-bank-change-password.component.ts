import { Component, importProvidersFrom, OnInit } from '@angular/core';
import { BloodBank } from '../model/blood-bank.model';
import { BloodBankService } from '../services/blood-bank.service';
import { Router, UrlSegment } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PasswordReset } from '../model/passwordReset.model';


@Component({
  selector: 'app-blood-bank-change-password',
  templateUrl: './blood-bank-change-password.component.html',
  styleUrls: ['./blood-bank-change-password.component.css']
})
export class BloodBankChangePasswordComponent implements OnInit {

  public passKey : String = new String();
  public bloodBank : BloodBank = new BloodBank();
  public newPassword: PasswordReset = new PasswordReset();
  public repeatedPassword: PasswordReset = new PasswordReset();

  constructor(private toastr: ToastrService,private route: ActivatedRoute, private bloodBankService: BloodBankService, private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams
    .subscribe(params => {
      this.passKey = params['passKey'];
    }
    );
    //OVO TREBA DA SE JOS PROVERI ZASTO NE RADI TA PROVERA 
    this.bloodBankService.checkBankExist(this.passKey).subscribe(res => {
      this.toastr.success("Change password");
      console.log(res);
    }, (error) => {
      this.toastr.error('Bank not found')
    });
  }

  public changePassword(){
    if(!this.isValidInput()) return;
    console.log(this.newPassword);
    console.log(this.repeatedPassword);
    this.bloodBankService.changePassword(this.newPassword, this.passKey).subscribe(res =>
    this.router.navigate(['/home']));
    }

  private isValidInput(): boolean {
    var isValid = this.newPassword.password == this.repeatedPassword.password && this.newPassword.password.length > 7; 
    if(isValid){
      return true;
    }else{
      console.log("Incorrect  ");
      return false;
    }
  }

}
