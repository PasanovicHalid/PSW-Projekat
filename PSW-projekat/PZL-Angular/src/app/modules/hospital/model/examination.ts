import { Appointment } from "./appointment.model";
import { Prescription } from "./prescription";
import { Symptom } from "./symptom";

export class Examination {
    id: number;
    deleted: boolean;
    appointment: Appointment;
    prescriptions: Prescription[];
    symptoms: Symptom[];
    report: string;

    public constructor(id: any, deleted: any, appointment: any,
        prescriptions: any, symptoms: any, report:any) {
        this.id = id;
        this.deleted = deleted;
        this.appointment = appointment;
        this.prescriptions = prescriptions;
        this.symptoms = symptoms;
        this.report = report;

    }
}