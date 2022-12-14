import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from 'src/app/app-routing.module'; 
import { HomePatientComponent } from './homePatient/homePatient.component';
import { BankHomeComponent } from './bank-home/bank-home.component';

const routes: Routes = [
  { path: 'homePatient', component: HomePatientComponent },
  { path: 'bank-home', component: BankHomeComponent },
];

@NgModule({
  declarations: [
    HomePatientComponent,
    BankHomeComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class PagesModule { }
