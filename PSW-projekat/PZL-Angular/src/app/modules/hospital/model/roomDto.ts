import { Bed } from "./bed";
import { BedDto } from "./bedDto";
import { Blood } from "./blood";
import { Medicine } from "./medicine";
import { RoomType } from "./roomType";

export class RoomDto {
    id: number = 0;
    number: string = '';
    floor: number = 0;
    roomType: RoomType;
    bedDtos: BedDto[];

    public constructor(id: any, number: any, floor: any, roomType: any, bedDtos: any) {
        this.id = id;
        this.number = number;
        this.floor = floor;
        this.roomType = roomType;
        this.bedDtos = bedDtos;

    }

    
}