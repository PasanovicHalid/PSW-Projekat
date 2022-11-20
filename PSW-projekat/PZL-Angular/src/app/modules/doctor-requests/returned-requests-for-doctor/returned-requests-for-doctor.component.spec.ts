import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnedRequestsForDoctorComponent } from './returned-requests-for-doctor.component';

describe('ReturnedRequestsForDoctorComponent', () => {
  let component: ReturnedRequestsForDoctorComponent;
  let fixture: ComponentFixture<ReturnedRequestsForDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReturnedRequestsForDoctorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnedRequestsForDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
