import { RoomDetailComponent } from "../room-detail/room-detail.component";
import { PatientDto } from "./patientDto";
import { Room} from "./room.model";
import { RoomDto } from "./roomDto";
import { Therapy } from "./therapy";
import { TreatmentState } from "./treatmentState";

export class Treatment {
    id: number;
    deleted: boolean;
    patient: PatientDto;
    dateAdmission: Date;
    dateDischarge: Date;
    reasonForAdmission: string = '';
    reasonForDischarge: string = '';
    treatmentState: TreatmentState;
    therapy: Therapy;
    room: RoomDto;

    public constructor(id: any, deleted: any, patient: any, dateAdmission: any, dateDischarge: any, reasonForAdmission: any, reasonForDischarge: any, treatmentState: any, therapy: any, room: any) {
        this.id = id;
        this.deleted = deleted;
        this.patient = patient;
        this.dateAdmission = dateAdmission;
        this.dateDischarge = dateDischarge;
        this.reasonForAdmission = reasonForAdmission;
        this.reasonForDischarge = reasonForDischarge;
        this.treatmentState = treatmentState;
        this.therapy = therapy;
        this.room = room;

    }
}