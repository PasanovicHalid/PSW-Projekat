import { Pipe, PipeTransform } from '@angular/core';
import { Medicine } from '../model/medicine';

@Pipe({
  name: 'showMedicine'
})
export class ShowMedicinePipe implements PipeTransform {

  transform(medicines: Medicine[]): String {

    let toRet = "";
    medicines.forEach((element, index) => {
      if(index == medicines.length - 1){
        toRet += element.name;
      } else {
        toRet += element.name + ", ";
      }
    })
    return toRet;
  }

}
