import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Room } from '../model/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    return this.http.get<Room[]>('api/rooms', {headers: this.headers});
  }

  getRoom(id: number): Observable<Room> {
    return this.http.get<Room>('api/rooms/' + id, {headers: this.headers});
  }

  deleteRoom(id: any): Observable<any> {
    return this.http.delete<any>('api/rooms/' + id, {headers: this.headers});
  }

  createRoom(room: any): Observable<any> {
    return this.http.post<any>('api/rooms', room, {headers: this.headers});
  }

  updateRoom(room: any): Observable<any> {
    return this.http.put<any>('api/rooms/' + room.id, room, {headers: this.headers});
  }
}
