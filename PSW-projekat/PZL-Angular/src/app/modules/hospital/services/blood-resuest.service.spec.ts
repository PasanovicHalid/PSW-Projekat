import { TestBed } from '@angular/core/testing';

import { BloodResuestService } from './blood-request.service';

describe('BloodResuestService', () => {
  let service: BloodResuestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BloodResuestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
