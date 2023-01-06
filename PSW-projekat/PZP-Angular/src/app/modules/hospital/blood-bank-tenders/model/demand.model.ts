import { BloodType } from "./bloodType";

export class Demand {
    bloodType: BloodType = BloodType.ABMinus;
    quantity: number = 0;

    public constructor(obj?:any){
        if(obj){
            this.bloodType = obj.bloodType;
            this.quantity = obj.quantity;
        }
    }
}
