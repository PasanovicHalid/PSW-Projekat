export class DoctorForPatientRegistrationDto {
    id: number = 0;
    fullName: string = '';
  
    public constructor(id?: any, fullName?: any) {
        this.id = id;
        this.fullName = fullName;
    }
  }
  