import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmissionPatientTreatmentComponent } from './admission-patient-treatment.component';

describe('AdmissionPatientTreatmentComponent', () => {
  let component: AdmissionPatientTreatmentComponent;
  let fixture: ComponentFixture<AdmissionPatientTreatmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdmissionPatientTreatmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdmissionPatientTreatmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
