import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {
   userName=null;
  sub: Subscription;//משתנה מסוג שיודע לשמור הירשמות לקבל עדיכונים

  constructor(public userSer: UserService) { }
  ngOnDestroy(): void {
    this.sub.unsubscribe();

  }

  ngOnInit(): void {
    // this.userName = this.userSer.getFromStorage()?.name;
    // this.userName = this.userSer.getFromStorage() ? this.userSer.getFromStorage().name : "guest";
    //שמורים את ההירשמות כדי שיהיה אפשר לבטלה
    this.sub = this.userSer.currentUser.subscribe(succ => {
      this.userName = succ?.name;
      console.log("from subscribe")
    })
  }
  logOut() {
    this.userSer.removeFromStorage()
    this.userSer.currentUser.next(null);
  }

}
