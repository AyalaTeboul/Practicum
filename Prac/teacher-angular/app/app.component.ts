import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(public ser: UserService) {

  }
  ngOnInit(): void {
    this.ser.currentUser.next(this.ser.getFromStorage())
  }
  title = 'lesson13';
}
