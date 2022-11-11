import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./modules/pages/home/home.component";
import { AppointmentsComponent } from "./modules/hospital/appointments/appointments.component"


const routes: Routes = [
  {path: 'appointment', component: AppointmentsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
