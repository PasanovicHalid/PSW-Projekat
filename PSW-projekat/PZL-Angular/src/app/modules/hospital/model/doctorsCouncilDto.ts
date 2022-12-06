import { DoctorDto } from "./doctorDto";

export class DoctorsCouncilDto {
    
    id: number = 0;
    topic: string = '';
    start: Date;
    duration: number = 0;
    doctors: DoctorDto[];

    public constructor(id: any, topic:any, start: any, duration:any, doctors: any) {
        this.id = id;
        this.topic = topic;
        this.start = start;
        this.duration = duration;
        this.doctors = doctors;
    }
}