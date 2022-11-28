import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTendersComponent } from './view-tenders.component';

describe('ViewTendersComponent', () => {
  let component: ViewTendersComponent;
  let fixture: ComponentFixture<ViewTendersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewTendersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewTendersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
