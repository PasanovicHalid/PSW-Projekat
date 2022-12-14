import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalExaminationPatientComponent } from './medical-examination-patient.component';

describe('MedicalExaminationPatientComponent', () => {
  let component: MedicalExaminationPatientComponent;
  let fixture: ComponentFixture<MedicalExaminationPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicalExaminationPatientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalExaminationPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
