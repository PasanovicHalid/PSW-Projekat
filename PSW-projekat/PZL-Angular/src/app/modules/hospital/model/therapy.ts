import { Blood } from "./blood";
import { Medicine } from "./medicine";

export class Therapy {
    id: number;
    deleted: boolean;
    medicine: Medicine;
    blood: Blood;
    quantitytMedicine: number = 0;
    quantityBlood: number = 0;

    public constructor(id: any, deleted: any, medicine: any, blood: any, quantitytMedicine: any, quantityBlood: any ) {
        this.id = id;
        this.deleted = deleted;
        this.medicine = medicine;
        this.blood = blood;
        this.quantitytMedicine = quantitytMedicine;
        this.quantityBlood =quantityBlood;

    }
}