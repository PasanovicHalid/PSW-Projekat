import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { PatientDto } from '../model/patientDto';
import { Room } from '../model/room.model';
import { Treatment } from '../model/treatment';
import { TreatmentState } from '../model/treatmentState';
import { RoomService } from '../services/room.service';
import { TreatmentService } from '../services/treatment.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-discharge-patient',
  templateUrl: './discharge-patient.component.html',
  styleUrls: ['./discharge-patient.component.css']
})
export class DischargePatientComponent implements OnInit {

  public treatment: Treatment = new Treatment(0, false, PatientDto, Date(), new Date(),'', '', TreatmentState.close, null, Room);
  public dataSourcePatients = new MatTableDataSource<PatientDto>();
  public dataSourceRooms = new MatTableDataSource<Room>();
  public patients: PatientDto[] = [];
  public rooms: Room[] = [];
  public newPatient1: PatientDto = new PatientDto(0, '','','','', 0);

  constructor(private treatmentService: TreatmentService, private userService: UserService, private roomService: RoomService, private router: Router, private route: ActivatedRoute ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.treatmentService.getTreatment(params['id']).subscribe(res => {
        this.newPatient1 = res.patient;
        console.log(this.newPatient1);
        console.log(res);
        this.treatment = res;
    })


    /*this.userService.GetAllPatients().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new PatientDto(element.id, element.name, element.surname, element.email, element.username, element.role);
        this.patients.push(app);
      });
      console.log(this.patients);
      this.dataSourcePatients.data = this.patients;
    })*/

    this.roomService.getRooms().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Room(element.id, element.deleted, element.number, element.floor, element.roomType, element.medicines, element.bloods, element.beds);
        this.rooms.push(app);
      });
      this.dataSourceRooms.data = this.rooms;
    })
   });
  }
  public updateTreatment(): void {
    if (!this.isValidInput()) return;
    this.treatmentService.updateTreatment(this.treatment).subscribe(res => {
      console.log(this.treatment);
      this.router.navigate(['/treatments']);
      window.confirm("The patient was discharged from hospital!");
    });
  }

  private isValidInput(): boolean {
    return true;
  }

}
