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
  public displayedColumns = ['description', 'username', 'public', 'dateCreated'];
  public feedbacks: FeedbackDto[] = [];

  constructor(private feedbackService: FeedbackService, private router: Router) { }

  ngOnInit(): void {
    this.feedbackService.getFeedbacks().subscribe(res => {
      this.feedbacks = res;
      this.dataSource.data = this.feedbacks;
    })
  }

}