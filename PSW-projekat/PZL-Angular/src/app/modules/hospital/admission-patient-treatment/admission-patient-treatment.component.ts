import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BedDto } from '../model/bedDto';
import { PatientDto } from '../model/patientDto';
import { Room } from '../model/room.model';
import { Bed } from '../model/bed';
import { Therapy } from '../model/therapy';
import { Treatment } from '../model/treatment';
import { TreatmentState } from '../model/treatmentState';
import { RoomService } from '../services/room.service';
import { TreatmentService } from '../services/treatment.service';
import { UserService } from '../services/user.service';
import { BedService } from '../services/bed.service';
import { PatientService } from '../services/patient.service';
import { Role } from '../model/role';
import { RoomDto } from "../model/roomDto";



@Component({
  selector: 'app-admission-patient-treatment',
  templateUrl: './admission-patient-treatment.component.html',
  styleUrls: ['./admission-patient-treatment.component.css']
})
export class AdmissionPatientTreatmentComponent implements OnInit {

  public treatment: Treatment = new Treatment(0, false, PatientDto, Date(), new Date(),'', '', TreatmentState.close, null, RoomDto);
  public dataSourcePatients = new MatTableDataSource<PatientDto>();
  public dataSourceRooms = new MatTableDataSource<RoomDto>();
  public dataSourceBeds = new MatTableDataSource<BedDto>();

  public patients: PatientDto[] = [];
  public rooms: RoomDto[] = [];
  public kreveti: BedDto[] = [];
  public idk: number = 0;
  public pomK: BedDto;
  public idp: number = 0;

  constructor(private treatmentService: TreatmentService, private roomService: RoomService, 
              private bedService: BedService, private patientService: PatientService, private router: Router) { }

  public handleOptionChangeRoom() {
     this.idk = this.treatment.roomDto.id;
     this.kreveti = [];
    this.roomService.GetAllBedsByRoom(this.idk).subscribe(res =>
      {
        let result = Object.values(JSON.parse(JSON.stringify(res)));
        result.forEach((element: any) => {
          var bed = new BedDto(element.id, element.deleted, element.name, element.bedState, element.patientDto, element.quantity);
          this.kreveti.push(bed);
      })
      this.dataSourceBeds.data = this.kreveti;
      console.log(this.kreveti);

    })
  } 

  ngOnInit(): void { 
    this.patientService.GetPatientsNoTreatment().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new PatientDto(element.id, element.name, element.surname, element.email, element.username, element.role);
        this.patients.push(app);
      });
      this.dataSourcePatients.data = this.patients;
    })

    this.roomService.getRooms().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new RoomDto(element.id, element.number, element.floor, element.roomType, element.bedDtos);
        this.rooms.push(app);
      });
      this.dataSourceRooms.data = this.rooms;
    })

  }

  public handleOptionChangePatient() {
    return this.treatment.patient;
  }

  public handleOptionChangeBed() {
    this.pomK.patientDto = this.handleOptionChangePatient();
    this.bedService.updateBed(this.pomK).subscribe(res => {
      window.confirm("The bed was succesed update!");
    })
  }

  public createTreatment() {
    console.log(this.treatment);
    if (!this.isValidInput()){
      window.confirm("The fields are not valid entered!") }
    this.treatmentService.createTreatment(this.treatment).subscribe(res => {
      window.confirm("The patient was admitted for inpatient treatment!");
    });
  }

  private isValidInput(): boolean {
    //ne zaboravi da dodas terapiju kasnije
    return this.treatment?.patient.toString() != ''  && this.treatment?.dateAdmission.toString() != '' && this.treatment?.reasonForAdmission.toString() != ''  && this.treatment?.roomDto.toString() != '';
  }

}
