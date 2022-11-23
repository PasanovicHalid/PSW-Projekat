import { TestBed } from '@angular/core/testing';

import { AuthGuardDoctor } from './authDoctor.guard';

describe('AuthGuard', () => {
  let service: AuthGuardDoctor;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthGuardDoctor);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
