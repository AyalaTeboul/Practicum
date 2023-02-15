import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
    newPerson=new BehaviorSubject<{FirstName:string,LastName:string}>(null);
    
  constructor() { }
  
  saveStorage(user) {
    localStorage.setItem("Person", JSON.stringify(user));
  }
  getStorage() {
    let input = localStorage.getItem("Person");
    if (!input)
      return "";
    return JSON.parse(input);
  }
  removeStorage() {
    localStorage.removeItem("Person");
  }
}
