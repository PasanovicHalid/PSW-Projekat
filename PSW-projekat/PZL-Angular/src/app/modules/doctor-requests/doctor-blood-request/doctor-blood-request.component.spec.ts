import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorBloodRequestComponent } from './doctor-blood-request.component';

describe('DoctorBloodRequestComponent', () => {
  let component: DoctorBloodRequestComponent;
  let fixture: ComponentFixture<DoctorBloodRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorBloodRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorBloodRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
