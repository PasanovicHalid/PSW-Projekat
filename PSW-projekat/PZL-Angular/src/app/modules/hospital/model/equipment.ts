import { Bed } from "./bed";
import { Blood } from "./blood";
import { DoctorDto } from "./doctor";
import { Medicine } from "./medicine";
import { PatientDto } from "./patient";

export class Equipment {
    id: number;
    deleted: boolean;
    bed: Bed;
    blood: Blood;
    medicine: Medicine;

    public constructor(id: any, deleted: any, bed: any, blood: any, medicine: any) {
        this.id = id;
        this.deleted = deleted;
        this.bed = bed;
        this.blood = blood;
        this.medicine = medicine;

    }
}