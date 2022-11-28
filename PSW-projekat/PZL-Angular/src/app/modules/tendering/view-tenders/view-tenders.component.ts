import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Tender } from '../model/tender.model';
import { TenderService } from '../services/tender.service';
// import { BloodType } from '../model/blood-type';

@Component({
  selector: 'app-view-tenders',
  templateUrl: './view-tenders.component.html',
  styleUrls: ['./view-tenders.component.css']
})
export class ViewTendersComponent implements OnInit {

  public dataSource = new MatTableDataSource<Tender>();
  public displayedColumns = ['Open Until', 'State'];
  public tenders: Tender[] = [];
  public errorMessage: any;
  constructor(private tenderService: TenderService, private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem("currentUserRole") == 'Manager'){
      this.getTenders();
    }
    else{
      this.router.navigate(['/forbidden-access']);
    }
  }
  public getTenders(){
    this.tenderService.getTenders().subscribe(res => {
        this.dataSource.data = res;
      }, (error) => {
        this.errorMessage = error;
      });
  }

}
