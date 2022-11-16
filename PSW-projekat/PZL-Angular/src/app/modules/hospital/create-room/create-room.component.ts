import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Room } from 'src/app/modules/hospital/model/room.model';
import { RoomService } from 'src/app/modules/hospital/services/room.service';
import { Equipment } from '../model/equipment';

@Component({
  selector: 'app-create-room',
  templateUrl: './create-room.component.html',
  styleUrls: ['./create-room.component.css']
})
export class CreateRoomComponent {

  //smor
  public room: Room = new Room(0, false, 0, 0, 0, Equipment);

  constructor(private roomService: RoomService, private router: Router) { }

  public createRoom() {
    if (!this.isValidInput()) return;
    this.roomService.createRoom(this.room).subscribe(res => {
      this.router.navigate(['/rooms']);
    });
  }

  private isValidInput(): boolean {
    return this.room?.number != '' && this.room?.floor.toString() != '';
  }
}
