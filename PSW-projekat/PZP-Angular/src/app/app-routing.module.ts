import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./modules/pages/home/home.component";
import { RoomsComponent } from "./modules/hospital/rooms/rooms.component";
import { WelcomeComponent } from "./modules/hospital/welcome/welcome.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'room', component: RoomsComponent },
  { path: '', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
