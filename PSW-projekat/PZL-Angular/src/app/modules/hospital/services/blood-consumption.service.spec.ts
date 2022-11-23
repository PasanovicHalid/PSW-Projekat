import { TestBed } from '@angular/core/testing';

import { BloodConsumptionService } from './blood-consumption.service';

describe('BloodConsumptionService', () => {
  let service: BloodConsumptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BloodConsumptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
