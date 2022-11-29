import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAppontment } from './create-appontment.component';

describe('CreateAppontment', () => {
  let component: CreateAppontment;
  let fixture: ComponentFixture<CreateAppontment>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAppontment ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateAppontment);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
