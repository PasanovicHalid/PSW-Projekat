import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduledRequestComponent } from './scheduled-request.component';

describe('ScheduledRequestComponent', () => {
  let component: ScheduledRequestComponent;
  let fixture: ComponentFixture<ScheduledRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScheduledRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduledRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
