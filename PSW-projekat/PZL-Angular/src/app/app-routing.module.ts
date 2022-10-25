import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BloodBankRegistrationComponent } from './modules/blood-bank/blood-bank-registration/blood-bank-registration.component';

const routes: Routes = [
  { path: 'blood-bank-registration', component: BloodBankRegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
