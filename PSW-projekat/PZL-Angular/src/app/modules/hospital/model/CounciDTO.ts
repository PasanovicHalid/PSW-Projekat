import { Data } from "@angular/router";
import { DoctorDto } from "./doctorDto";
import { Specialization } from "./specialization";

export class CouncilDTO {
    id: number = 0;
    doctorId:number;
    topic:String;
    deleted: boolean = false;
    doctors:DoctorDto[]=[];
    specializations:Specialization[]=[];
    start:Data;
    end:Data;
    duration:number;

    public constructor(id: any, doctorId:any, start: any, end: any, topic: any, duration: any) {
        this.id = id;
        this.start = start;
        this.doctorId = doctorId;
        this.end = end;
        this.duration = duration;
        this.topic = topic;
    }
}