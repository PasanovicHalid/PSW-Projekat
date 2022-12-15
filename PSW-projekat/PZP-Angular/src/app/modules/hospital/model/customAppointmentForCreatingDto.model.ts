export class CustomAppointmentForCreatingDto {
    DoctorID: string;
    PersonID: string;
    CreateDate: string;
    
    public constructor(
        doctorID: string = '',
        personID: string = '',
        createDate: string = ''
    ) {
        this.DoctorID = doctorID;
        this.PersonID = personID;
        this.CreateDate = createDate;
    }
}
  