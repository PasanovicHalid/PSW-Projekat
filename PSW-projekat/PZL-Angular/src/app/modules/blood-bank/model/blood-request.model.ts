export class BloodRequest {
    bloodType: string = '';
    quantity: number = 0;
    bloodBankID: string = '';

    public constructor(obj?: any) {
        if (obj){
            this.bloodType = obj.bloodType;
            this.quantity = obj.quantity;
            this.bloodBankID = obj.bloodBankID;
        }
    }
}