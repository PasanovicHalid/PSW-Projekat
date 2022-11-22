import { Allergy } from "./allergy.model";
import { DoctorForPatientRegistrationDto } from "./doctorForPatientRegistrationDto.model";

export class LoginUserDto {
    username: string = '';
    password: string = '';
    flag: string = 'PZP';


    public constructor(obj?: any) {
        if (obj) {
            this.username = obj.username;
            this.password = obj.password;
            this.flag = 'PZP';
        }
    }
  }
