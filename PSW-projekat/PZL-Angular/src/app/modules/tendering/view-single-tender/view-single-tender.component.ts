import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { TenderState } from '../model/tender-state.enum';
import { Tender } from '../model/tender.model';
import { TenderService } from '../services/tender.service';

@Component({
  selector: 'app-view-single-tender',
  templateUrl: './view-single-tender.component.html',
  styleUrls: ['./view-single-tender.component.css']
})
export class ViewSingleTenderComponent implements OnInit {

  constructor(private tenderService: TenderService, private router: Router) { }

  ngOnInit(): void {
  }

}
