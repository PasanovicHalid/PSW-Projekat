import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from 'src/app/app-routing.module'; 
import { HomeDoctorComponent } from './homeDoctor/homeDoctor.component';
import { HomeManagerComponent } from './homeManager/homeManager.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'homeManager', component: HomeManagerComponent },
  { path: 'homeDoctor', component: HomeDoctorComponent },
];

@NgModule({
  declarations: [
    HomeDoctorComponent,
    HomeManagerComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    RouterModule.forChild(routes),
  ]
})
export class PagesModule { }
