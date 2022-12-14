export class AppointmentAvailableForCreatingAppointment{
    dayInWeek: string ='';
    date: string = '';
    time: string = '';
    doctorFullName: string = '';
    specialtization: string = '';
    doctorID: number = 0;

    public constructor(obj?: any) {
        this.dayInWeek = obj.dayInWeek;
        this.date = obj.dayAndDate;
        this.time = obj.time;
        this.doctorFullName = obj.doctorFullName;
        this.specialtization = obj.specialtization;
        this.doctorID = obj.doctorID;
    }
}