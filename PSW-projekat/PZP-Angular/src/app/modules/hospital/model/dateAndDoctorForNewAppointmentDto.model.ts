export class DateAndDoctorForNewAppointmentDto {
    scheduledDate: Date = new Date();
    doctorId?: number;
  
    public constructor(obj?: any) {
        if (obj) {
            this.scheduledDate = obj.scheduledDate;
            this.doctorId = obj.doctorId;
        }
    }
  }