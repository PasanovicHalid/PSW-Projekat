import { BloodBankRegistrationComponent } from "../../blood-banks/blood-bank-registration/blood-bank-registration.component";
import { BedState } from "./bedState";
import { PatientDto } from "./patientDto";

export class BedDto {
    id: number = 0;
    deleted: boolean;
    name: string = '';
    bedState: BedState;
    patientDto: PatientDto;
    quantity: number = 0;

    public constructor(id: any, deleted: any, name: any, bedState:any, patientDto: any, quantity: any) {
        this.id = id;
        this.deleted = deleted;
        this.name = name;
        this.bedState = bedState;
        this.patientDto = patientDto;
        this.quantity = quantity;

    }
}