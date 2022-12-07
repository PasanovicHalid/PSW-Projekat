export class MaliciousPatientDto {
    id: number = 0;
    fullname: string = '';
    username: string = '';
    isblocked: string = '';

    public constructor(id: any, fullname:any, username: any, isblocked:any) {
        this.id = id;
        this.fullname = fullname;
        this.username = username;
        this.isblocked = isblocked;
    }
}