import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllDoctorBloodRequestsComponent } from './all-doctor-blood-requests/all-doctor-blood-requests.component';
import { RouterModule, Routes } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { MatTableModule } from '@angular/material/table';
import { DoctorBloodRequestComponent } from './doctor-blood-request/doctor-blood-request.component';

const routes: Routes = [
  {path: 'doctor-blood-requests', component: AllDoctorBloodRequestsComponent },
  {path: 'doctor-blood-request/:id', component: DoctorBloodRequestComponent }
];


@NgModule({
  declarations: [
    AllDoctorBloodRequestsComponent,
    DoctorBloodRequestComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    RouterModule.forChild(routes),
    ToastrModule.forRoot()
  ],

  exports: [ RouterModule ]
})
export class DoctorRequestsModule { }
