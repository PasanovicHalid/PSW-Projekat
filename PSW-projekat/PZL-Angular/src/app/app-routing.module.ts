import { NgModule } from '@angular/core';
import { BloodBankRegistrationComponent } from './modules/blood-bank/blood-bank-registration/blood-bank-registration.component';
import { BloodBankChangePasswordComponent } from './modules/blood-bank/blood-bank-change-password/blood-bank-change-password.component';
import { BloodBanksComponent } from './modules/blood-bank/blood-banks/blood-banks.component';
import { BloodRequestsComponent } from './modules/blood-bank/blood-requests/blood-requests.component';
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./modules/pages/home/home.component";
import { AppointmentsComponent } from "./modules/hospital/appointments/appointments.component"


const routes: Routes = [
  { path: 'blood-bank-registration', component: BloodBankRegistrationComponent},
  { path: 'home', component: HomeComponent },
  {path: 'blood-banks', component: BloodBanksComponent},
  {path: 'blood-bank-change-password', component: BloodBankChangePasswordComponent},
  {path: 'blood-requests', component: BloodRequestsComponent},
  {path: 'appointment', component: AppointmentsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
