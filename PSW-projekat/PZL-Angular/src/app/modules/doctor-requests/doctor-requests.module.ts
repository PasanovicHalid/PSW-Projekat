import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllDoctorBloodRequestsComponent } from './all-doctor-blood-requests/all-doctor-blood-requests.component';
import { RouterModule, Routes } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { MatTableModule } from '@angular/material/table';
import { DoctorBloodRequestComponent } from './doctor-blood-request/doctor-blood-request.component';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/app/material/material.module';
import { ReturnedRequestsForDoctorComponent } from './returned-requests-for-doctor/returned-requests-for-doctor.component';

const routes: Routes = [
  {path: 'doctor-blood-requests', component: AllDoctorBloodRequestsComponent },
  {path: 'doctor-blood-request/:id', component: DoctorBloodRequestComponent },
  {path: 'doctor-blood-request/:id', component: ReturnedRequestsForDoctorComponent }
];


@NgModule({
  declarations: [
    AllDoctorBloodRequestsComponent,
    DoctorBloodRequestComponent,
    ReturnedRequestsForDoctorComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    RouterModule.forChild(routes),
    ToastrModule.forRoot()
  ],

  exports: [ RouterModule ]
})
export class DoctorRequestsModule { }
