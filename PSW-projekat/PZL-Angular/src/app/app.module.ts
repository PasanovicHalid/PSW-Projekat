import { BloodBankRegistrationComponent } from './modules/blood-bank/blood-bank-registration/blood-bank-registration.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule} from '@angular/material/input';
import { MatSelectModule} from '@angular/material/select'; 
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { BloodBanksComponent } from './modules/blood-bank/blood-banks/blood-banks.component';
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { MaterialModule } from "./material/material.module";
import { HospitalModule } from "./modules/hospital/hospital.module";
import { PagesModule } from "./modules/pages/pages.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BloodRequestsComponent } from './modules/blood-bank/blood-requests/blood-requests.component';
import { BloodBankChangePasswordComponent } from './modules/blood-bank/blood-bank-change-password/blood-bank-change-password.component';

@NgModule({
  declarations: [
    AppComponent,
    BloodBankRegistrationComponent,
    BloodBanksComponent,
    BloodRequestsComponent,
    BloodBankChangePasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    PagesModule,
    HospitalModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
