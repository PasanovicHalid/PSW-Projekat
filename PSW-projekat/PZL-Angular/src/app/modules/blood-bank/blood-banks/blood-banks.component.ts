import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BloodBank } from '../model/blood-bank.model';
import { BloodBankService } from '../services/blood-bank.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-blood-banks',
  templateUrl: './blood-banks.component.html',
  styleUrls: ['./blood-banks.component.css']
})
export class BloodBanksComponent implements OnInit {

  public dataSource = new MatTableDataSource<BloodBank>();
  public displayedColumns = ['name', 'email'];
  public bloodBanks: BloodBank[] = [];
  public errorMessage: any;

  constructor(private bloodBankService: BloodBankService, private router: Router) { }

  ngOnInit(): void {
    this.bloodBankService.getBloodBanks().subscribe(res => {
      this.bloodBanks = res;
      this.dataSource.data = res;
    }, (error) => {
      this.errorMessage = error;
    })
  }
  public chooseBloodBank(id:number){
    this.router.navigate(['blood-banks', id]);
  }

}
