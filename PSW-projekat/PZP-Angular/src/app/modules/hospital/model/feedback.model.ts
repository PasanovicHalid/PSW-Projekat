export class Feedback {
  id: number = 0;
  description: string = '';
  isAnonimous: boolean = false;
  isPublic: boolean = false;
  dateCreated: Date = new Date();
  userId: string = '0';
  status: FeedbackStatus = FeedbackStatus.Pending;

  public constructor(obj?: any) {
      if (obj) {
          this.id = obj.id;
          this.description = obj.number;
          this.isAnonimous = obj.isAnonimous;
          this.isPublic = obj.isPublic;
          this.dateCreated = obj.dateCreated;
          this.userId = obj.userId;
          this.status = obj.status;
      }
  }
}
export enum FeedbackStatus {
  Pending, 
  Accepted, 
  Rejected
}
