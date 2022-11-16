import { Equipment } from "./equipment";
import { RoomType } from "./roomType";

export class Room {
    id: number = 0;
    deleted: boolean;
    number: string = '';
    floor: number = 0;
    roomType: RoomType;
    equipment: Equipment;

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
    public constructor(id: any, deleted:any, number: any, floor: any, roomType: any, equipment: any) {
        this.id = id;
        this.deleted = deleted;
        this.number = number;
        this.floor = floor;
        this.roomType = roomType;
        this.equipment = equipment;

    }

    
}