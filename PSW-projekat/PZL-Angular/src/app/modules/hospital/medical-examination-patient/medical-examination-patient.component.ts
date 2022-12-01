import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Appointment } from '../model/appointment.model';
import { Examination } from '../model/examination';
import { Medicine } from '../model/medicine';
import { PatientDto } from '../model/patientDto';
import { Prescription } from '../model/prescription';
import { Role } from '../model/role';
import { Symptom } from '../model/symptom';
import { AppointmentService } from '../services/appointment.service';
import { MedicineService } from '../services/medicine.service';
import { PatientService } from '../services/patient.service';
import { RoomService } from '../services/room.service';
import { SymptomService } from '../services/symptom.service';

@Component({
  selector: 'app-medical-examination-patient',
  templateUrl: './medical-examination-patient.component.html',
  styleUrls: ['./medical-examination-patient.component.css']
})
export class MedicalExaminationPatientComponent implements OnInit{

  public dataSourceSymptoms = new MatTableDataSource<Symptom>();

  //public patient: PatientDto = new PatientDto(2, '', '', '', '', Role)
  public symptoms: Symptom[] = [];
  public simptomi: Symptom[] = [];
  public prescriptions: Prescription[] = [];
  public patient: PatientDto = new PatientDto(0, '','','','', 0);
  public appointment: Appointment = new Appointment(0, false, '', '', Date());
  public examination: Examination = new Examination(0, false, Appointment, this.prescriptions, this.simptomi,'');

  constructor(private patientService: PatientService, private symptomService: SymptomService,
     private medicineService: MedicineService, private route: ActivatedRoute, 
     private appointmentService: AppointmentService, private router: Router) { }

  ngOnInit(): void {

    this.route.params.subscribe((params: Params) => {
      this.appointmentService.getAppointment(params['id']).subscribe(res => {
        console.log(params['id']);
        console.log(res);
        this.patient = res.patient;
        this.appointment = res;
      })
    });

    this.symptomService.getSymptoms().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Symptom(element.id, element.deleted, element.name);
        this.symptoms.push(app);
      });
      this.dataSourceSymptoms.data = this.symptoms;
    })

  }

  public handleOptionChangeSymptoms() {
    return this.examination.symptoms;
  }


}


@Component({
  templateUrl: 'medical-report.component.html',
  styleUrls: ['./medical-examination-patient.component.css']
})
export class MedicalReportComponent implements OnInit {

  public report: string = '';
  constructor() { }

  ngOnInit(): void {
  }

}

@Component({
  templateUrl: 'medical-prescription.html',
  styleUrls: ['./medical-examination-patient.component.css']
})
export class MedicalPrescriptionComponent implements OnInit {

  public lekovi: Medicine[] = [];
  public medicines: Medicine[] = [];
  public prescription: Prescription = new Prescription(0,0, this.lekovi, '')
  public dataSourceMedicines = new MatTableDataSource<Medicine>();

  constructor(private roomService: RoomService, private router: Router) { }

  ngOnInit(): void {
    this.roomService.getAllStorageMedicnes().subscribe(res => {
      let result = Object.values(JSON.parse(JSON.stringify(res)));
      result.forEach((element: any) => {
        var app = new Medicine(element.id, element.deleted, element.name, element.quantity);
        this.medicines.push(app);
      });
      this.dataSourceMedicines.data = this.medicines;
    })
  }

  public handleOptionChangeMedicines() {
    return this.prescription.medicines;
  }

}


@Component({
  templateUrl: 'medical-examination-finish.html',
  styleUrls: ['./medical-examination-patient.component.css']
})
export class MedicalExaminationFinish implements OnInit {

  public lekovi: Medicine[] = [];
  public medicines: Medicine[] = [];
  public prescription: Prescription = new Prescription(0,0, this.lekovi, '')
  public dataSourceMedicines = new MatTableDataSource<Medicine>();

  constructor() { }

  ngOnInit(): void {
 
  }


}


