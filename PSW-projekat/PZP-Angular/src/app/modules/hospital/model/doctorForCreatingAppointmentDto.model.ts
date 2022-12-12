export class DoctorForCreatingAppointmentDto{
    id: number = 0;
    fullName: string = "";
    specialization: string = "";
  
    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.fullName = obj.fullName;
            this.specialization = obj.specialization;
        }
    }
}