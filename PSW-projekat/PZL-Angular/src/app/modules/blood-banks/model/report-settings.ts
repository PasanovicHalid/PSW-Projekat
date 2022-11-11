export class ReportSettings {
    startDeliveryDate: Date = new Date();
    deliveryYears: number = 0;
    deliveryMonths: number = 0;
    deliveryDays: number = 0;
    calculationYears: number = 0;
    calculationMonths: number = 0;
    calculationDays: number = 0;

    public constructor(obj?: any){
        if(obj){
            this.deliveryYears = obj.deliveryYears;
            this.deliveryMonths = obj.deliveryMonths;
            this.deliveryDays = obj.deliveryDays;
            this.startDeliveryDate = obj.startDeliveryDate;
            this.calculationYears = obj.calculationYears;
            this.calculationMonths = obj.calculationMonths;
            this.calculationDays = obj.calculationDays;
        }
    }
}
