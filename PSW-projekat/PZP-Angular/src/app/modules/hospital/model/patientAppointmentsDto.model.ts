export class PatientAppointment {
  appointmentId: number;
  doctorFullName: string;
  appointmentTime: Date;
  appointmentStatus: string

  public constructor(id: any, doctor: any, dateTime: any, appointmentStatus: any) {
      this.appointmentId = id;
      this. doctorFullName = doctor;
      this.appointmentTime = dateTime;
      this.appointmentStatus = appointmentStatus
  }
}
