import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { TenderState } from '../model/tender-state.enum';
import { Tender } from '../model/tender.model';
import { TenderService } from '../services/tender.service';
import { BloodType } from '../../doctor-requests/model/blood-type';
import { Demand } from '../model/demand.model';

@Component({
  selector: 'app-create-tender',
  templateUrl: './create-tender.component.html',
  styleUrls: ['./create-tender.component.css']
})
export class CreateTenderComponent implements OnInit {

  isVisible: boolean = false;
  isTableVisible: boolean = false;
  public bloodTypes : BloodType[] = [BloodType.ON,BloodType.AN, BloodType.BN, BloodType.ABN, BloodType.OP, BloodType.AP, BloodType.BP, BloodType.ABP];
  tender: Tender = new Tender();
  demand: Demand = new Demand();
  

  constructor(private tenderService: TenderService, private router: Router) { }

  ngOnInit(): void {
    this.tender.demands = [];
  }

  addDemand(){
    if(this.isDemandValid()){
      this.isVisible = !this.isVisible;
      this.tender.demands.push(this.demand)
      this.isTableVisible = true;
      this.demand = new Demand();
    }   
  }

  isDemandValid(){
    if(this.demand.quantity <= 0 || this.demand.quantity > 10 || this.demand.quantity == undefined){
        return false;
    }
    return true;
  }

  deleteDemand(d: Demand,index : number){   
    if (index !== -1) {
      this.tender.demands.splice(index, 1);
    }  
    if(this.tender.demands.length == 0)
        this.isTableVisible = false;
  }

  createTender(){
    this.tenderService.createTender(this.tender).subscribe(res => {
      this.router.navigate(['/view-tenders']);
    });
  }

  displayDemandCreation(){
    this.isVisible = !this.isVisible;
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
  getBloodByValue(value: number) {
    return Object.values(BloodType)[value]
  }
}
