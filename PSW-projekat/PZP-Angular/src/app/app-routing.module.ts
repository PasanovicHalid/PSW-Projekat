import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./modules/pages/home/home.component";
import { RoomsComponent } from "./modules/hospital/rooms/rooms.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'room', component: RoomsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
