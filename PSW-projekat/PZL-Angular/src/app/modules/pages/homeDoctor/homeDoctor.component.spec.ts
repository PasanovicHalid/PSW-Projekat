import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeDoctorComponent } from './homeDoctor.component';

describe('HomeComponent', () => {
  let component: HomeDoctorComponent;
  let fixture: ComponentFixture<HomeDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeDoctorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
