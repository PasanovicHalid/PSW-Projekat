import { TestBed } from '@angular/core/testing';

import { ReportSettingsService } from './report-settings.service';

describe('ReportSettingsService', () => {
  let service: ReportSettingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReportSettingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
