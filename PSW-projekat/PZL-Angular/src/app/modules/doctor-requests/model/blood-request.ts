import { BloodType } from "./blood-type";
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
}
