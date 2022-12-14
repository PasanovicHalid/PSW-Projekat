import { Pipe, PipeTransform } from '@angular/core';
import { DoctorDto } from '../model/doctorDto';

@Pipe({
  name: 'showDoctors'
})
export class ShowDoctorsPipe implements PipeTransform {

  transform(doctors: DoctorDto[]): String {
    let toRet = "";
    doctors.forEach((element, index) => {
      if(index == doctors.length - 1){
        toRet += element.name + " " + element.surname;
      } else {
        toRet += element.name + " " + element.surname + ", ";
      }
    })
    return toRet;
  }

}
