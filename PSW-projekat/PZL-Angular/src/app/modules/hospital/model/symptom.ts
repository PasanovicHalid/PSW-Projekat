import { DoctorDto } from "./doctorDto";
import { PatientDto } from "./patientDto";

export class Symptom {
    id: number;
    deleted: boolean;
    name: string;

    public constructor(id: any, deleted: any, name: any) {
        this.id = id;
        this.deleted = deleted;
        this.name = name;

    }
}