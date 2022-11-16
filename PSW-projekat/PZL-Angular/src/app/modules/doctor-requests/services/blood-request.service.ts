import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { BloodRequest } from '../model/blood-request';
import { Doctor } from '../model/doctor';
import { DoctorBloodRequest } from '../model/doctor-blood-request';

@Injectable({
  providedIn: 'root'
})
export class BloodRequestService {

  integrationApiHost: string = "http://localhost:5000/";
  hospitalApiHost: string = "http://localhost:16177/";
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getBloodRequests(): Observable<BloodRequest[]> {
    return this.http.get<BloodRequest[]>(this.integrationApiHost + 'api/BloodRequest', {headers: this.headers}).pipe(catchError(this.handleError))
  }

  getDoctors(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(this.hospitalApiHost + 'api/Person/doctor', {headers: this.headers}).pipe(catchError(this.handleError))
  }

  getBloodRequest(id : number): Observable<any> {
    return this.http.get<BloodRequest>(this.integrationApiHost + 'api/BloodRequest/' + id, {headers: this.headers}).pipe(catchError(this.handleError))
  }

  getDoctor(id : number): Observable<Doctor> {
    return this.http.get<Doctor>(this.hospitalApiHost + 'api/Person/doctor/' + id, {headers: this.headers}).pipe(catchError(this.handleError))
  }

  
  private handleError(error: HttpErrorResponse) {
    return throwError(() => new Error(error.status +'\n'+ error.error))
  }

  combineDoctorsWithRequests(requests : BloodRequest[], doctors : Doctor[]) : DoctorBloodRequest[] {
      var result : DoctorBloodRequest[] = [];
      requests.forEach(request => {
        let bloodRequest : DoctorBloodRequest = new DoctorBloodRequest();
        bloodRequest.combineWithBloodRequest(request);
        for (let doctor of doctors) {
          if(doctor.id == request.doctorId){
            bloodRequest.doctor = doctor;
            break;
          }
        }
        result.push(bloodRequest);
      });
      return result;
  }
}
