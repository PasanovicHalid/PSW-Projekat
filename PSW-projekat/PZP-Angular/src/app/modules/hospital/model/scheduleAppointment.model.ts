import { DoctorForPatientRegistrationDto } from "./doctorForPatientRegistrationDto.model";

export class ScheduleAppointment {
    scheduledDate: Date = new Date();
    doctorDto: DoctorForPatientRegistrationDto = new DoctorForPatientRegistrationDto();
    patientId: string|null = '0';
  
    public constructor(obj?: any) {
        if (obj) {
            this.scheduledDate = obj.scheduledDate;
            this.doctorDto = obj.doctorDto;
            this.patientId = obj.patientId;
        }
    }
  }
  export enum Specialization {
    general,
    dermatology,
    neurology,
    urology,
    gynecology,
    cardiology,
    dentistry,
    otorhinolaryngology
  }