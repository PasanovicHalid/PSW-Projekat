export class Appointment {
    id: number;
    dateTime: Date;
    patientName: string;
    patientSurname: string;


    public constructor(id: any, dateTime: any, patientName: any, patientSurname: any) {
        // if (obj) {
        //     this.id = obj.id;
        //     this.dateTime = obj.dateTime;
        //     this.patientName = obj.patientName;
        //     this.patientSurname = obj.patientSurname;        
        // }
        this.id = id;
        this.dateTime = dateTime;
        this.patientName = patientName;
        this.patientSurname = patientSurname;
    }
}