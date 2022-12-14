export class StatisticsDto {
    NumberOfMalesPerAgeGroup : any[];
    NumberOfFemalesPerAgeGroup : any[];
    BloodtypePopularity : Map<string,number>;
    AllergyPopularity : Map<string,number>;
    DoctorAgeGroups : Map<string,number[]>;
  
    public constructor(obj?: any) {
        if (obj) {
            this.NumberOfMalesPerAgeGroup = obj.NumberOfMalesPerAgeGroup;
            this.NumberOfFemalesPerAgeGroup = obj.NumberOfFemalesPerAgeGroup;
            this.BloodtypePopularity = obj.BloodtypePopularity;
            this.AllergyPopularity = obj.AllergyPopularity;
            this.DoctorAgeGroups = obj.DoctorAgeGroups;
        }
    }
  }

  export class DoctorStat {
    Name : string;
    one : number;
    two : number;
    three : number;
    four : number;
    five : number;
    six : number;

    public constructor(name: string,one : number,two : number,three : number,four : number,five : number,six : number) {
        this.Name = name;
        this.one = one;
        this.two = two;
        this.three = three;
        this.four = four;
        this.five = five;
        this.six = six;
    }
  }