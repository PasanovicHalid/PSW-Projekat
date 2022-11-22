export class UserInfoDto {
    id: number = 0;
    name: string = '';
    surname: string = '';
    gender: Gender = Gender.male;
    birthDate: string = '';
    email: string = '';
    street: string = '';
    number: string = '';
    city: string = '';
    township: string = '';
    postCode: string = '';

  public constructor(obj?: any) {
      if (obj) {
          this.id = obj.id;
          this.name = obj.name;
          this.surname = obj.surname;
          this.gender = obj.gender;
          this.birthDate = obj.birthDate;
          this.email = obj.email;
          this.street = obj.street;
          this.number = obj.number;
          this.city = obj.city;
          this.township = obj.township;
          this.postCode = obj.postCode;
      }
  }
}
export enum Gender {
  male,
  female,
  other
}
