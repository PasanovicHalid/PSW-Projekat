import { BloodType } from "./blood-type";

export class EmergencyBloodRequest {
    bloodQuantity : number = 0;
    bloodType : BloodType
    bloodBankID : number = -1;
}
