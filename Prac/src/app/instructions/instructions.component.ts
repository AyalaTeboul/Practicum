import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import Person from '../model/Person';
import { UserService } from '../userService';

@Component({
  selector: 'app-instructions',
  templateUrl: './instructions.component.html',
  styleUrls: ['./instructions.component.scss']
})
export class InstructionsComponent implements OnInit {

  subscribe: Subscription;
  firstName="";
  lastName="";
  constructor(public userService: UserService) { }
  ngOnDestroy(): void {
    this.userService.newPerson.next(null);
    this.subscribe.unsubscribe();
  }

  ngOnInit(): void {

    this.subscribe = this.userService.newPerson.subscribe(suc => {
      this.firstName = suc?.FirstName
      this.lastName = suc?.LastName
    })
  }
 }

