import { BloodBankRegistrationComponent } from "../../blood-banks/blood-bank-registration/blood-bank-registration.component";
import { BedState } from "./bedState";
import { Equipment } from "./equipment";
import { PatientDto } from "./patient";

export class Bed {
    id: number;
    deleted: boolean;
    name: string = '';
    bedState: BedState;
    patient: PatientDto;
    equipment: Equipment;

    public constructor(id: any, deleted: any, name: any, patient: any, equipment: any) {
        this.id = id;
        this.deleted = deleted;
        this.name = name;
        this.patient = patient;
        this.equipment = equipment;

    }
}