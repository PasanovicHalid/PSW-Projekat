import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomePatientComponent } from "./modules/pages/homePatient/homePatient.component";
import { RoomsComponent } from "./modules/hospital/rooms/rooms.component";
import { WelcomeComponent } from "./modules/hospital/welcome/welcome.component";

const routes: Routes = [
  { path: 'room', component: RoomsComponent },
  { path: '', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
