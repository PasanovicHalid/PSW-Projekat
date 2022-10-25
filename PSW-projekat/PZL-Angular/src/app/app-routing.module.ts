import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BloodBanksComponent } from './modules/blood-bank/blood-banks/blood-banks.component';

const routes: Routes = [
  {path: 'blood-banks', component: BloodBanksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
