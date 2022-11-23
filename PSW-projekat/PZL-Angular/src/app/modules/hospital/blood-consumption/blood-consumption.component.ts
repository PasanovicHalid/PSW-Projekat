import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Blood } from '../model/blood';
import { BloodConsumption } from '../model/blood-consumption';
import { BloodType } from '../model/bloodType';
import { BloodConsumptionService } from '../services/blood-consumption.service';

@Component({
  selector: 'app-blood-consumption',
  templateUrl: './blood-consumption.component.html',
  styleUrls: ['./blood-consumption.component.css']
})
export class BloodConsumptionComponent implements OnInit {
  public bloodConsumption: BloodConsumption = new BloodConsumption(0,new Blood(0,false,'',''),'', localStorage.getItem("currentUserId"))
  public bloodType: String = ''
  constructor(private bloodConsumptionService: BloodConsumptionService, private router: Router) { }
  ngOnInit(): void {
    
  }

  public ConvertFromString(obj: any): any{
    switch(obj){
      case '0': return 0;
      case '1': return 1;
      case '2': return 2;
      case '3': return 3;
      case '4': return 4;
      case '5': return 5;
      case '6': return 6;
      case '7': return 7;
      
    }
  }

  public createRoom() {
    this.bloodConsumption.blood.bloodType = this.ConvertFromString(this.bloodType );
    console.log(this.bloodConsumption )
    if (!this.isValidInput()) return;
    this.bloodConsumptionService.createBloodConsumption(this.bloodConsumption).subscribe(res => {
      this.router.navigate(['/appointments']);
    });
  }

  private isValidInput(): boolean {
    return this.bloodConsumption?.purpose != '' && this.bloodConsumption?.blood.quantity.toString() != '' && this.bloodType !="";
  }
}
