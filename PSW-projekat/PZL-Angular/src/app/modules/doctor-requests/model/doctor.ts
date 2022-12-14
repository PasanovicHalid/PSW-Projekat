export class Doctor {
    id: number;
    name: string;
    surname: string;
    public Doctor(obj?: any) {
        
        this.id = obj?.id ?? -1;
        this.name = obj?.name ?? '';
        this.surname = obj?.surname ?? '';
    }
}
