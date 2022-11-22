import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountActivationInfo } from './account-activation-info.component';

describe('AccountActivationInfo', () => {
  let component: AccountActivationInfo;
  let fixture: ComponentFixture<AccountActivationInfo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountActivationInfo ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountActivationInfo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
