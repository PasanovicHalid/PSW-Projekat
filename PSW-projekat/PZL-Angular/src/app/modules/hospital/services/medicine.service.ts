import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Medicine } from '../model/medicine';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getMedicines(): Observable<Medicine[]> {
    return this.http.get<Medicine[]>(this.apiHost + 'api/medicines', {headers: this.headers});
  }

  getMedicine(id: number): Observable<Medicine> {
    return this.http.get<Medicine>(this.apiHost + 'api/medicines/' + id, {headers: this.headers});
  }

  deleteMedicine(id: any): Observable<any> {
    return this.http.delete<any>(this.apiHost + 'api/medicines/' + id, {headers: this.headers});
  }

  createMedicine(medicine: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/medicines', medicine, {headers: this.headers});
  }

  updateMedicine(medicine: any): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/medicines/' + medicine.id, medicine, {headers: this.headers});
  }

  updateQuantityMedicine(medicine: any, quantity: number): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/medicine/medicines/' + medicine.id + "/"+ quantity, medicine, {headers: this.headers});
  }


}
