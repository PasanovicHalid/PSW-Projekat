import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Patient } from '../model/patient1';
import { Room } from '../model/room.model';
import { Therapy } from '../model/therapy';
import { Treatment } from '../model/treatment';
import { TreatmentService } from '../services/treatment.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-admission-patient-treatment',
  templateUrl: './admission-patient-treatment.component.html',
  styleUrls: ['./admission-patient-treatment.component.css']
})
export class AdmissionPatientTreatmentComponent implements OnInit {

  public treatment: Treatment = new Treatment(0, false, Patient, Date(), Date(),'', '', 0, Therapy, Room);
  public dataSource = new MatTableDataSource<Patient>();
  public patients: Patient[] = [];

  constructor(private treatmentService: TreatmentService, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
   
    this.userService.GetAllPatients().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Patient(element.id, element.deleted, element.bloodType, element.person, element.doctor);
        this.patients.push(app);
      });
      console.log(this.patients);
      this.dataSource.data = this.patients;
    })
  }
  
  public createTreatment() {
    console.log(this.treatment);
    if (!this.isValidInput()) return;
    this.treatmentService.createTreatment(this.treatment).subscribe(res => {
      this.router.navigate(['/treatments']);
    });
  }

  private isValidInput(): boolean {
    return this.treatment?.patient.toString() != ''  && this.treatment?.dateAdmission.toString() != '' && this.treatment?.reasonForAdmission.toString() != '' && this.treatment?.treatmentState.toString() != '' && this.treatment?.therapy.toString() != '' && this.treatment?.room.toString() != '';
  }

}
