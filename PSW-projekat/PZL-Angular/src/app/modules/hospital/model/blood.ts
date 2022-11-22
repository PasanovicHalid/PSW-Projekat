import { BloodType } from "./bloodType";

export class Blood {
    id: number;
    deleted: boolean;
    bloodType: BloodType;
    quantity: number = 0;

    public constructor(id: any, deleted: any, bloodType: any, quantity: any) {
        this.id = id;
        this.deleted = deleted;
        this.bloodType = bloodType;
        this.quantity = quantity;
    }
}