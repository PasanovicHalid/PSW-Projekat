import { BloodBankRegistrationComponent } from "../../blood-banks/blood-bank-registration/blood-bank-registration.component";
import { BedState } from "./bedState";
import { Patient } from "./patient";
import { PatientDto } from "./patientDto";

export class Bed {
    id: number = 0;
    deleted: boolean;
    name: string = '';
    bedState: BedState;
    patient: Patient;
    quantity: number = 0;

    public constructor(id: any, deleted: any, name: any, bedState:any, patient: any, quantity: any) {
        this.id = id;
        this.deleted = deleted;
        this.name = name;
        this.bedState = bedState;
        this.patient = patient;
        this.quantity = quantity;

    }
}