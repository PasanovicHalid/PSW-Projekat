import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BloodBankRegistrationComponent } from './modules/blood-bank/blood-bank-registration/blood-bank-registration.component';
import { BloodBanksComponent } from './modules/blood-bank/blood-banks/blood-banks.component';

const routes: Routes = [
  { path: 'blood-bank-registration', component: BloodBankRegistrationComponent},
  {path: 'blood-banks', component: BloodBanksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
