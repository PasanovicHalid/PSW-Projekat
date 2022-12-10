import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MaliciousPatientDto } from '../model/maliciousPatientDto';
import { LoginService } from '../services/login.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-malicious-patients',
  templateUrl: './malicious-patients.component.html',
  styleUrls: ['./malicious-patients.component.css']
})
export class MaliciousPatientsComponent implements OnInit {

  constructor(private patientService: PatientService, private loginService: LoginService) { }

  public dataSource = new MatTableDataSource<MaliciousPatientDto>();
  public displayedColumns = ['Name','Username','Status','Block'];

  ngOnInit(): void {
    this.patientService.GetMaliciousPatients().subscribe(res => {
      this.dataSource.data = res;
    })
  }

  public blockPatient(id: any){
    this.patientService.BlockPatient(id).subscribe(res => {
      this.ngOnInit();
    })
  }

  public unblockPatient(id: any){
    this.patientService.UnblockPatient(id).subscribe(res => {
      this.ngOnInit();
    })
  }

  logoutUser(){
    this.loginService.logout().subscribe(res => {
      
    })
  }

}
