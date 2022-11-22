import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from 'src/app/app-routing.module'; 
import { HomePatientComponent } from './homePatient/homePatient.component';

const routes: Routes = [
  { path: 'homePatient', component: HomePatientComponent },
];

@NgModule({
  declarations: [
    HomePatientComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class PagesModule { }
