import { BloodRequest } from "./blood-request";
import { BloodType } from "./blood-type";
import { Doctor } from "./doctor";
import { RequestState } from "./request-state";

export class DoctorBloodRequest {
    id : number = 0;
    requiredForDate : Date = new Date();
    bloodQuantity: number = 0;
    reason: string = '';
    doctor: Doctor = new Doctor();
    requestState: RequestState = RequestState.Pending;
    bloodType: BloodType = BloodType.ABN;
    comment : string = '';

    public combineWithBloodRequest(request : BloodRequest) {
        this.id = request.id;
        this.requiredForDate = request.requiredForDate;
        this.bloodQuantity = request.bloodQuantity;
        this.reason = request.reason;
        this.requestState = request.requestState;
        this.bloodType = request.bloodType;
    }
}
