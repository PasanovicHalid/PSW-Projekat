import { DoctorDto } from "./doctorDto";
import { PatientDto } from "./patientDto";

export class Appointment {
    id: number;
    deleted: boolean;
    patient: PatientDto;
    doctor: DoctorDto;
    dateTime: Date;
    cancelationDate: Date;

    public constructor(id: any, deleted: any, patient: any, doctor: any, dateTime: any, cancelationDate: any) {
        this.id = id;
        this.deleted = deleted;
        this.patient = patient;
        this.doctor = doctor;
        this.dateTime = dateTime;
        this.cancelationDate = cancelationDate;
    }
}