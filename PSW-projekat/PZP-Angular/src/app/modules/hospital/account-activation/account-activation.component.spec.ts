import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountActivationThanks } from './account-activation.component';

describe('AccountActivationThanks', () => {
  let component: AccountActivationThanks;
  let fixture: ComponentFixture<AccountActivationThanks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountActivationThanks ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountActivationThanks);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
