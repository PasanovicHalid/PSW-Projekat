import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BloodConsumptionComponent } from './blood-consumption.component';

describe('BloodConsumptionComponent', () => {
  let component: BloodConsumptionComponent;
  let fixture: ComponentFixture<BloodConsumptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BloodConsumptionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BloodConsumptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
