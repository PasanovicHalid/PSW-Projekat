export class FeedbackDto {
    id: number = 0;
    description: string = '';
    isPublic: string = '';
    dateCreated: Date = new Date();
    username: string = '';

    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.FeedbackId;
            this.description = obj.Description;
            this.username = obj.Username;
            this.isPublic = obj.Public;
            this.dateCreated = obj.DateCreated;
        }
    }
}
  