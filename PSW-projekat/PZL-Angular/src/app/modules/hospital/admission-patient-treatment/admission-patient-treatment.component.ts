import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { PatientDto } from '../model/patient';
import { Patient } from '../model/patient1';
import { Room } from '../model/room.model';
import { Therapy } from '../model/therapy';
import { Treatment } from '../model/treatment';
import { TreatmentState } from '../model/treatmentState';
import { RoomService } from '../services/room.service';
import { TreatmentService } from '../services/treatment.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-admission-patient-treatment',
  templateUrl: './admission-patient-treatment.component.html',
  styleUrls: ['./admission-patient-treatment.component.css']
})
export class AdmissionPatientTreatmentComponent implements OnInit {

  public treatment: Treatment = new Treatment(0, false, PatientDto, Date(), new Date(),'', '', TreatmentState.close, null, Room);
  public dataSourcePatients = new MatTableDataSource<PatientDto>();
  public dataSourceRooms = new MatTableDataSource<Room>();
  public patients: PatientDto[] = [];
  public rooms: Room[] = [];

  constructor(private treatmentService: TreatmentService, private userService: UserService, private roomService: RoomService, private router: Router) { }

  ngOnInit(): void {
   
    this.userService.GetAllPatients().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new PatientDto(element.id, element.name, element.surname, element.email, element.username, element.role);
        this.patients.push(app);
      });
      console.log(this.patients);
      this.dataSourcePatients.data = this.patients;
    })

    this.roomService.getRooms().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Room(element.id, element.deleted, element.number, element.floor, element.roomType, element.equipment);
        this.rooms.push(app);
      });
      this.dataSourceRooms.data = this.rooms;
    })
  }
  
  public createTreatment() {
    console.log(this.treatment);
    if (!this.isValidInput()) return;
    this.treatmentService.createTreatment(this.treatment).subscribe(res => {
      window.confirm("The patient was admitted for inpatient treatment!");
    });
  }

  private isValidInput(): boolean {
    //ne zaboravi da dodas terapiju kasnije
    return this.treatment?.patient.toString() != ''  && this.treatment?.dateAdmission.toString() != '' && this.treatment?.reasonForAdmission.toString() != ''  && this.treatment?.room.toString() != '';
  }

}
