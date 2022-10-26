export class Appointment {
    id: number = 0;
    date: Date = new Date() ;
    time: string = '';
    patientId: number = 0;


    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.date = obj.date;
            this.time = obj.time;
            this.patientId = obj.patientId;        
        }
    }
}