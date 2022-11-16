import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllDoctorBloodRequestsComponent } from './all-doctor-blood-requests.component';

describe('AllDoctorBloodRequestsComponent', () => {
  let component: AllDoctorBloodRequestsComponent;
  let fixture: ComponentFixture<AllDoctorBloodRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllDoctorBloodRequestsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllDoctorBloodRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
