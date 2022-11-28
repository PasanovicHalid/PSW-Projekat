import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSingleTenderComponent } from './view-single-tender.component';

describe('ViewSingleTenderComponent', () => {
  let component: ViewSingleTenderComponent;
  let fixture: ComponentFixture<ViewSingleTenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSingleTenderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSingleTenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
