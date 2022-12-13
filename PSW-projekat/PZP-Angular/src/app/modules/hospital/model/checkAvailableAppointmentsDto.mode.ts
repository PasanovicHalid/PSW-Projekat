export class CheckAvailableAppontmentDto {
    fromDate: string;
    toDate: string;
    fromTime: string;
    toTime: string;
    prefer: string;
    selectedDoctorID: number;
    personID: number;
    
    public constructor(
        fromDate: string = '',
        toDate: string = '',
        fromTime: string = '',
        toTime: string = '',
        prefer: string = '',
        selectedDoctorID: number = 0,
        personID: number = 0
    ) {
        this.fromDate = fromDate;
        this.toDate = toDate;
        this.fromTime = fromTime;
        this.toTime = toTime;
        this.prefer = prefer;
        this.selectedDoctorID = selectedDoctorID;
        this.personID = personID;
    }
  }
  