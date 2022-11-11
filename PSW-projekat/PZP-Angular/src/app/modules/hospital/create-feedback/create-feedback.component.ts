import { Component, OnInit } from '@angular/core';
import { Feedback } from 'src/app/modules/hospital/model/feedback.model';
import { FeedbackService } from 'src/app/modules/hospital/services/feedback.service';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';


@Component({
  selector: 'app-create-feedback',
  templateUrl: './create-feedback.component.html',
  styleUrls: ['./create-feedback.component.css']
})
export class CreateFeedbackComponent{

  public feedback: Feedback = new Feedback();


  constructor(private feedbackService: FeedbackService, private router: Router) { }

  public createFeedback() {
    const token = "eyJhbGciOiJub25lIiwidHlwIjoiSldUIn0.eyJOYW1lIjoicGVyYSIsImp0aSI6Ijk3ZDg4YzI1LTk1OWItNDJjYi1iOGE2LTMwNTY0MzZmM2EwYSIsIlJvbGUiOiJNYW5hZ2VyIiwiZXhwIjoxNjcwNzc5MDQ3fQ.";

    const tokenInfo = this.getDecodedAccessToken(token); // decode token
    console.log(tokenInfo.Role)
    localStorage.setItem('currentUser', token);
    let currentUser = localStorage.getItem("currentUser");
    if (!this.isValidInput()) return;
    this.feedbackService.createFeedback(this.feedback).subscribe(res => {
      this.router.navigate(['']);
    });
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }

  private isValidInput(): boolean {
    return this.feedback?.description != '';
  }

}
