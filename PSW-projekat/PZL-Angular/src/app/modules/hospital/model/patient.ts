import { BloodType } from "./bloodType";
import { Doctor } from "./doctor";
import { Person } from "./person";
import { Role } from "./role";

export class Patient{
    id: number = 0;
    deleted: boolean = false;
    bloodType: BloodType;
    person: Person;
    doctor: Doctor;

    public constructor(id: any, deleted:any, bloodType: any, person:any, doctor: any) {
        this.id = id;
        this.deleted = deleted;
        this.bloodType = bloodType;
        this.person = person;
        this.doctor = doctor;
    }
}