import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScheduledRequest } from '../model/scheduled-order';
import { ScheduledRequestsService } from '../services/scheduled-requests.service';

@Component({
  selector: 'app-scheduled-request',
  templateUrl: './scheduled-request.component.html',
  styleUrls: ['./scheduled-request.component.css'],
})
export class ScheduledRequestComponent implements OnInit {
  public scheduledRequest: ScheduledRequest = new ScheduledRequest();
  public errorMessage: any;
  constructor(
    private scheduledRequestService: ScheduledRequestsService,
    private router: Router
  ) {}

  ngOnInit(): void {}
  public sendRequest() {
    this.scheduledRequest.id = 0;
    this.scheduledRequest.bankApiKey = '';
    this.scheduledRequest.hospitalEmail = 'hospital@gmail.com';
    this.scheduledRequestService
      .createRequest(this.scheduledRequest)
      .subscribe((res) => {});
  }
}
