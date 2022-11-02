import { Day } from "./day";

export class WorkingDay {
    id: number = 0;
    deleted: boolean = false;
    dayOfWeek: number = 0 ;
    day: Day = 0;
    startTime: Date = new Date();
    endTime: Date = new Date();

    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.deleted = obj.deleted;
            this.dayOfWeek = obj.dayOfWeek;
            this.day = obj.day;
            this.startTime = obj.startTime;
            this.endTime = obj.endTime;        
        }
    }
}