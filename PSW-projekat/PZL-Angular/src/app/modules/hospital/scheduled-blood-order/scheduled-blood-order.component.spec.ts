import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduledBloodOrderComponent } from './scheduled-blood-order.component';

describe('ScheduledBloodOrderComponent', () => {
  let component: ScheduledBloodOrderComponent;
  let fixture: ComponentFixture<ScheduledBloodOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScheduledBloodOrderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduledBloodOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
