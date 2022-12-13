import { Component, OnInit } from '@angular/core';
import { Tender } from '../model/tender.model';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Demand } from '../model/demand.model';
import { Bid } from '../model/bid.model';
import { BidStatus } from '../model/bid-status.enum';
import { TenderService } from '../services/tender.service';
import { BidService } from '../services/bid.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-tender-details',
  templateUrl: './tender-details.component.html',
  styleUrls: ['./tender-details.component.css']
})
export class TenderDetailsComponent implements OnInit {

  constructor(private tenderService: TenderService,private router: Router, private bidService: BidService) {
   }
  
  
  price: any;
  deliveryDate: any;
  public dataSource = this.tenderService.selectedTender.demands;
  selectedTender: Tender = this.tenderService.selectedTender;
  public displayedColumns = ['BloodType', 'Quantity'];
  public errorMessage: any;

  ngOnInit(): void {
  }

  public convertBloodType(blood: number): string{
    if(blood == 0){return 'A+';}
    else{if(blood == 1){return 'B+';}
    else{if(blood == 2){return 'AB+';}
    else{if(blood == 3){return '0+';}
    else{if(blood == 4){return 'A-'}
    else{if(blood == 5){return 'B-'}
    else{if(blood == 6){return 'AB-'}
    else{return '0-'}}}}}}}
  }

  private isNumber(number: any): boolean{
    const reg = new RegExp('^[0-9]+$');
    return reg.test(number);
  }
  
  public createBid(){
    if(this.deliveryDate == null || this.price == null){
      
      console.log("Fill all fields.");
    }else{
      if(!this.isNumber(this.price)){
        console.log(this.price, " is not nuber.");
      }else{
        //TODO: napraviti Bid
       let  bid = new Bid();
        bid.bloodBankId = 1; 
        bid.tenderOfBidId = this.tenderService.selectedTender.id;
        bid.deliveryDate = this.deliveryDate;
        bid.price = this.price;
        bid.status = BidStatus.WAITING;
        console.log(bid);
        this.bidService.createBid(bid).subscribe(res =>{
        console.log(res);
        this.router.navigate(['view-all-open-tenders']);  
        });
      }
    }
  }
}
