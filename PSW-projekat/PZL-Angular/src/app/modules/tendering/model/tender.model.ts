import { Demand } from "./demand.model";
import { TenderState } from "./tender-state.enum";

export class Tender {
    // id : number;
    dueDate : Date;
    demands: Demand[];
    state: TenderState;
    id: number;
}
    