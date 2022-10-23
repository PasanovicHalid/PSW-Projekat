export class Feedback {
  id: number = 0;
  description: string = '';
  isAnonimous: boolean = false;
  isPublic: boolean = false;
  dateCreated: Date = new Date();
  userId: string = '';

  public constructor(obj?: any) {
      if (obj) {
          this.id = obj.id;
          this.description = obj.number;
          this.isAnonimous = obj.isAnonimous;
          this.isPublic = obj.isPublic;
          this.dateCreated = obj.dateCreated;
          this.userId = obj.userId;
      }
  }
}
