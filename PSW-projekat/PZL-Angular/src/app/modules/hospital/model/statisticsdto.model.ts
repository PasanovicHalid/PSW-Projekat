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
    values : any[];

    public constructor(name: string,values: any[]) {
        this.Name = name;
        this.values = values;
    }
  }