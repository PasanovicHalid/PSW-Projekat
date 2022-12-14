import { Email } from "./email.model";

export class BloodBank {
    id: number = 0;
    name: string = '';
    email: Email  = new Email();
    password: string = '';
    serverAddress: string = '';
    apiKey: string = '';

    public constructor(obj?: any) {
        if (obj){
            this.id = obj.id;
            this.name = obj.name;
            this.email = obj.email;
            this.password = obj.password;
            this.serverAddress = obj.serverAddress;
            this.apiKey = obj.apiKey;
        }
    }
}