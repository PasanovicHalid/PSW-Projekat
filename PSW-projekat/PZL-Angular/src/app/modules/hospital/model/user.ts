import { WorkingDay } from "./workingDay";
import { Role } from "./role";

export class User {
    id: number = 0;
    deleted: boolean = false;
    name: string = '' ;
    surname: string = '';
    email: string = '';
    password: string = '';
    username: string = '';
    role: Role = 0;
    workingDays: WorkingDay[] = [];


    public constructor(id: any, name: any, surname: any, role: any) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.role = role
    }
}