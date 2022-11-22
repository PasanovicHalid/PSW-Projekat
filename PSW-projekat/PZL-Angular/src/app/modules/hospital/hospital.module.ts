import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { MaterialModule } from "src/app/material/material.module";
import { MatInput, MatInputModule} from '@angular/material/input';
import { CreateRoomComponent } from "./create-room/create-room.component";
import { RoomDetailComponent } from "./room-detail/room-detail.component";
import { RoomsComponent } from "./rooms/rooms.component";
import { UpdateRoomComponent } from "./update-room/update-room.component";
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSelectModule } from '@angular/material/select';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { AppointmentsComponent } from './appointments/appointments.component';
import { CreateAppointmentComponent } from './create-appointment/create-appointment.component';
import { UpdateAppointmentComponent } from "./update-appointment/update-appointment.component";
import { AdmissionPatientTreatmentComponent } from './admission-patient-treatment/admission-patient-treatment.component';
import { DischargePatientComponent } from './discharge-patient/discharge-patient.component';
import { LoginComponent } from "./login/login.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

const routes: Routes = [
  { path: 'rooms', component: RoomsComponent },
  { path: 'rooms/add', component: CreateRoomComponent },
  { path: 'rooms/:id', component: RoomDetailComponent },
  { path: 'rooms/:id/update', component: UpdateRoomComponent },
  { path: 'feedbacks', component: FeedbacksComponent },
  { path: 'appointments', component: AppointmentsComponent },
  { path: 'appointments/doctor/:id', component: AppointmentsComponent },
  { path: 'appointments/add', component: CreateAppointmentComponent },
  { path: 'appointments/:id/update', component: UpdateAppointmentComponent },
  { path: 'treatments/add', component: AdmissionPatientTreatmentComponent },
  { path: 'treatments/:id/update', component: DischargePatientComponent }
  { path: 'login', component: LoginComponent }
  
];

@NgModule({
  declarations: [
    RoomsComponent,
    RoomDetailComponent,
    CreateRoomComponent,
    UpdateRoomComponent,
    FeedbacksComponent,
    AppointmentsComponent,
    CreateAppointmentComponent,
    UpdateAppointmentComponent,
    AdmissionPatientTreatmentComponent,
    DischargePatientComponent
    LoginComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule

  ],
  exports: [ RouterModule ]
})
export class HospitalModule { }