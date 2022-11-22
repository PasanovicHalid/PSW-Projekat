import { Bed } from "./bed";
import { BedDto } from "./bedDto";
import { Blood } from "./blood";
import { Medicine } from "./medicine";
import { RoomType } from "./roomType";

export class Room {
    id: number = 0;
    deleted: boolean;
    number: string = '';
    floor: number = 0;
    roomType: RoomType;
    medicines: Medicine[];
    bloods: Blood[];
    beds: BedDto[];

    /*
    public constructor(obj?: any) {
        if (obj) {
            this.id = obj.id;
            this.number = obj.number;
            this.floor = obj.floor;
            this.roomType = obj.roomType;
            this.equipment = obj.equipment;        
        }
    }
    */
    public constructor(id: any, deleted:any, number: any, floor: any, roomType: any, medicines: any, bloods: any, beds: any) {
        this.id = id;
        this.deleted = deleted;
        this.number = number;
        this.floor = floor;
        this.roomType = roomType;
        this.medicines = medicines;
        this.bloods = bloods;
        this.beds = beds;

    }

    
}