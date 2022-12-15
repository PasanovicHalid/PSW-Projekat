import { TestBed } from '@angular/core/testing';

import { ScheduledRequestsService } from './scheduled-requests.service';

describe('ScheduledRequestsService', () => {
  let service: ScheduledRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScheduledRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
