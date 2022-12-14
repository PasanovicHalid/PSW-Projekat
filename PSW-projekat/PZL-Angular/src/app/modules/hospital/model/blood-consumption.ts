import { Blood } from "./blood";

export class BloodConsumption {
    id: number = 0;
    blood: Blood;
    purpose: string = '';
    doctorId: number;

    public constructor(id: any, blood: any, purpose: any, DoctorId: any) {
        this.id = id;
        this.blood = blood;
        this.purpose = purpose;
        this.doctorId = DoctorId;
    }
}