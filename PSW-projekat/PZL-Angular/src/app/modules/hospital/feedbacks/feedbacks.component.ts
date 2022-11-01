import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { FeedbackService } from 'src/app/modules/hospital/services/feedback.service';
import { FeedbackDto } from '../model/feedbackdto.model';

@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.css']
})
export class FeedbacksComponent implements OnInit {

  public dataSource = new MatTableDataSource<FeedbackDto>();
  public displayedColumns = ['description', 'username', 'public', 'dateCreated','status','updateStatus'];
  public feedbacks: FeedbackDto[] = [];

  constructor(private feedbackService: FeedbackService, private router: Router) { }

  ngOnInit(): void {
    this.feedbackService.getFeedbacks().subscribe(res => {
      this.feedbacks = res;
      this.dataSource.data = this.feedbacks;
    })
  }

  onApprove(feedbackDto:any){
    this.feedbackService.approve(feedbackDto).subscribe(res => {
      feedbackDto.status = "Approved";
    });
  }

  onReject(feedbackDto:any){    
    this.feedbackService.reject(feedbackDto).subscribe(res => {
      feedbackDto.status = "Rejected";
    });
  }

}