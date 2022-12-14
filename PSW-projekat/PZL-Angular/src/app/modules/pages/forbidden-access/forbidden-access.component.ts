import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-forbidden-access',
  templateUrl: './forbidden-access.component.html',
  styleUrls: ['./forbidden-access.component.css']
})
export class ForbiddenAccessComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var face = document.querySelector("i")!;
    let home = document.querySelector("a")!;

    home.addEventListener("mouseover", function() {
      face.classList.add("fa-smile", "green");
      // face.style.animationPlayState = "paused";
    });
    home.addEventListener("mouseout", function() {
      face.classList.remove("fa-smile", "green");
      // face.style.animationPlayState = "start";
    });
  }
  

}

