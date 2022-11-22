import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bed } from '../model/bed';
import { BedDto } from '../model/bedDto';

@Injectable({
  providedIn: 'root'
})
export class BedService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getBed(id: number): Observable<Bed> {
    return this.http.get<Bed>(this.apiHost + 'api/bed/' + id, {headers: this.headers});
  }

  updateBed(bed: any): Observable<any> {
    console.log(bed);
    return this.http.put<any>(this.apiHost + 'api/bed/' + bed.id, bed, {headers: this.headers});
  }
}
