import { Blood } from "./blood";
import { DoctorDto } from "./doctorDto";
import { Medicine } from "./medicine";
import { PatientDto } from "./patientDto";

export class Therapy {
    id: number;
    deleted: boolean;
    medicine: Medicine;
    blood: Blood;

    public constructor(id: any, deleted: any, medicine: any, blood: any) {
        this.id = id;
        this.deleted = deleted;
        this.medicine = medicine;
        this.blood = blood;

    }
}