import { Appointment } from "./appointment.model";
import { Medicine } from "./medicine";
import { Symptom } from "./symptom";

export class Prescription {
    id: number;
    deleted: boolean;
    medicines: Medicine[];
    description: string;

    public constructor(id: any, deleted: any, medicines: any, description: any) {
        this.id = id;
        this.deleted = deleted;
        this.medicines = medicines;
        this.description = description;

    }
}