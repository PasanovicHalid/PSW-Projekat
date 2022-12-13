import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllOpenTendersComponent } from './view-all-open-tenders.component';

describe('ViewAllOpenTendersComponent', () => {
  let component: ViewAllOpenTendersComponent;
  let fixture: ComponentFixture<ViewAllOpenTendersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAllOpenTendersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAllOpenTendersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
