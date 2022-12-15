export class ScheduledRequest {
  id: number;
  dayOfMonth: number;
  aPlus: number;
  bPlus: number;
  abPlus: number;
  oPlus: number;
  aMinus: number;
  bMinus: number;
  abMinus: number;
  oMinus: number;
  bankEmail: string;
  bankApiKey: string;
  hospitalEmail: string;

  public constructor(obj?: any) {
    if (obj) {
      this.id = obj.id;
      this.dayOfMonth = obj.dayOfMonth;
      this.aPlus = obj.aPlus;
      this.bPlus = obj.bPlus;
      this.abPlus = obj.abPlus;
      this.oPlus = obj.oPlus;
      this.aMinus = obj.aMinus;
      this.bMinus = obj.bMinus;
      this.abMinus = obj.abMinus;
      this.oMinus = obj.oMinus;
      this.bankEmail = obj.bankEmail;
      this.bankApiKey = obj.bankApiKey;
      this.hospitalEmail = obj.hospitalEmail;
    }
  }
}
