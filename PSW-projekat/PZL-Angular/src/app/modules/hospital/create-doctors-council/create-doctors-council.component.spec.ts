import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDoctorsCouncilComponent } from './create-doctors-council.component';

describe('CreateDoctorsCouncilComponent', () => {
  let component: CreateDoctorsCouncilComponent;
  let fixture: ComponentFixture<CreateDoctorsCouncilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDoctorsCouncilComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateDoctorsCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
