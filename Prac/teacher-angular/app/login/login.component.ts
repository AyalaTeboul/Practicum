import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user = { name: "", password: "" }
  constructor(public userService: UserService) { }
  logIn() {
    if (this.user.password.length > 4) {
      this.userService.saveInStorage(this.user);
      this.userService.currentUser.next(this.user);
    }
  }
  ngOnInit(): void {
  }

}
