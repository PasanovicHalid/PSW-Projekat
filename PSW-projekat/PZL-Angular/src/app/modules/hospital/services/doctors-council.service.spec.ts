import { TestBed } from '@angular/core/testing';

import { DoctorsCouncilService } from './doctors-council.service';

describe('DoctorsCouncilService', () => {
  let service: DoctorsCouncilService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorsCouncilService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
