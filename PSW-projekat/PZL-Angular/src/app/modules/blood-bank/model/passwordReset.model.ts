export class PasswordReset {
    password: string = '';

    public constructor(obj?: any) {
        if (obj){
            this.password = obj.password;
        }
    }
}