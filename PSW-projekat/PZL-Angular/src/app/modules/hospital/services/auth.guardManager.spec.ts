import { TestBed } from '@angular/core/testing';

import { AuthGuardManager } from './authManager.guard';

describe('AuthGuard', () => {
  let service: AuthGuardManager;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthGuardManager);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
