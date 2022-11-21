import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { AppointmentsComponent } from "./modules/hospital/appointments/appointments.component"
import { WelcomeComponent } from './modules/hospital/welcome/welcome.component';


const routes: Routes = [
  { path: 'appointment', component: AppointmentsComponent },
  { path: '', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
