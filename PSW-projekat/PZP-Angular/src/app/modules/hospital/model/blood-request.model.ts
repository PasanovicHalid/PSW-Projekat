export class BloodRequest {
    id: number = 0;
    bloodType: string = '';
    quantity: number = 0;
    isOpen: boolean = true;
    dateCreated: Date = new Date();
    bloodBankId: string = '';

    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.bloodType = obj.bloodType;
            this.quantity = obj.quantity;
            this.isOpen = obj.isOpen;
            this.dateCreated = obj.dateCreated;
            this.bloodBankId = obj.bloodBankId;
        }
    }
}
