import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BedDto } from '../model/bedDto';
import { Blood } from '../model/blood';
import { BloodType } from '../model/bloodType';
import { Medicine } from '../model/medicine';
import { Room } from '../model/room.model';
import { RoomDto } from '../model/roomDto';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  apiHost: string = 'http://localhost:16177/';
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getRooms(): Observable<RoomDto[]> {
    return this.http.get<RoomDto[]>(this.apiHost + 'api/rooms', {headers: this.headers});
  }

  getRoom(id: number): Observable<Room> {
    return this.http.get<Room>(this.apiHost + 'api/rooms/' + id, {headers: this.headers});
  }

  deleteRoom(id: any): Observable<any> {
    return this.http.delete<any>(this.apiHost + 'api/rooms/' + id, {headers: this.headers});
  }

  createRoom(room: any): Observable<any> {
    return this.http.post<any>(this.apiHost + 'api/rooms', room, {headers: this.headers});
  }

  updateRoom(room: any): Observable<any> {
    return this.http.put<any>(this.apiHost + 'api/rooms/' + room.id, room, {headers: this.headers});
  }

  GetAllBedsByRoom(roomId: number) : Observable<any[]> {
    return this.http.get<BedDto[]>(this.apiHost + 'api/rooms/room/' + roomId, {headers: this.headers});
  }

  getAllStorageMedicnes() : Observable<any[]> {
    return this.http.get<Medicine[]>(this.apiHost + 'api/rooms/room/medicines', {headers: this.headers});
  }

  getAllStorageBloods() : Observable<any[]> {
    return this.http.get<Blood[]>(this.apiHost + 'api/rooms/room/bloods', {headers: this.headers});
  }

}
