import { BloodType } from "./blood-type";
import { DoctorBloodRequest } from "./doctor-blood-request";
import { RequestState } from "./request-state";

export class BloodRequest {
    id : number;
    requiredForDate : Date;
    bloodQuantity: number;
    reason: string;
    doctorId: number;
    requestState: RequestState;
    bloodType: BloodType;
    bloodBankId: number;
    comment: string;

    public constructor(obj?: any) {
        if (obj){
            this.id = obj.id;
            this.requiredForDate = obj.requiredForDate;
            this.bloodQuantity = obj.bloodQuantity;
            this.reason = obj.reason;
            this.requestState = obj.requestState;
            this.bloodType = obj.bloodType;
            this.bloodBankId= obj.bloodBankId;
            this.doctorId = obj.doctor.id;
            this.comment = obj.comment;
        }
    }
}
