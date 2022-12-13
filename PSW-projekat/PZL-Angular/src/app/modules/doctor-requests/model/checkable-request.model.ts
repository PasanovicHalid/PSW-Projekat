export class CheckableRequest {
    bloodType: string = '';
    bloodQuantity: number = 0;
    bloodBankId: string = '';

    public constructor(obj?: any) {
        if (obj){
            this.bloodType = obj.bloodType;
            this.bloodQuantity = obj.bloodQuantity;
            this.bloodBankId = obj.bloodBankId;
        }
    }
}
