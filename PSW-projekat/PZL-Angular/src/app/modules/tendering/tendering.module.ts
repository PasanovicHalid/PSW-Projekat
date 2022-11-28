import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewTendersComponent } from './view-tenders/view-tenders.component';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule} from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { ToastrModule } from 'ngx-toastr';

const routes: Routes = [
  { path: 'view-tenders', component: ViewTendersComponent }
];

@NgModule({
  declarations: [
    ViewTendersComponent
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
export class TenderingModule { }
