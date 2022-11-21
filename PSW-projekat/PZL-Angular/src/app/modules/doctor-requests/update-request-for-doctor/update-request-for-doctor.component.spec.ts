import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRequestForDoctorComponent } from './update-request-for-doctor.component';

describe('UpdateRequestForDoctorComponent', () => {
  let component: UpdateRequestForDoctorComponent;
  let fixture: ComponentFixture<UpdateRequestForDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateRequestForDoctorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateRequestForDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
