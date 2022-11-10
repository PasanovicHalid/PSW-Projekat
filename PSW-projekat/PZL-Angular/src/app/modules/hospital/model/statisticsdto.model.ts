export class StatisticsDto {
    id: number = 0;
    description: string = '';
    username: string = '';
    public: string = '';
    dateCreated: string = '';
    status: string = '';
  
    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.description = obj.description;
            this.username = obj.username;
            this.public = obj.public;
            this.dateCreated = obj.dateCreated;
            this.status = obj.status;
        }
    }
  }
  //TODO change to adequate model