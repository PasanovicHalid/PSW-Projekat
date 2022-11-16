export class Medicine {
    id: number;
    deleted: boolean;
    name: string = "";
    quantity: number = 0;

    public constructor(id: any, deleted: any, name: any, quantity: any) {
        this.id = id;
        this.deleted = deleted;
        this.name = name;
        this.quantity = quantity;
    }
}