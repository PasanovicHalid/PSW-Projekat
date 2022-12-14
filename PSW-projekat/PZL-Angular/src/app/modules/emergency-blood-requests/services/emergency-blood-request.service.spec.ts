import { TestBed } from '@angular/core/testing';

import { EmergencyBloodRequestService } from './emergency-blood-request.service';

describe('EmergencyBloodRequestService', () => {
  let service: EmergencyBloodRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmergencyBloodRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
