import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  //subject יורש מ observable
  //מה שמיוחד בו:
  //1.זרם מידע אחד לכל המבקשים
  //2. ניתן לשלוח עדכונים וכדו' ממנו ומחוצה לו
  //בשונה מאובזרובל רגיל שרק מתוכו ניתן לעדכן

  currentUser=new BehaviorSubject<{name:string,password:string}>(null);
  //behvior- בשונה מסבגקט רגיל
  //הוא שולח לכל מי שנרשם לקבל את הערך של הנקסט האחרון שזקרו
  //אם לא היה שום נקסט הוא שולח ערך ברירת מחדל
  //ולכן הוא מחייב לשלוח ערך ברירת מחדל

  constructor() { }
  saveInStorage(user) {
    localStorage.setItem("currentUser", JSON.stringify(user));
  }
  getFromStorage() {
    let u = localStorage.getItem("currentUser");
    if (!u)
      return null;
    return JSON.parse(u);
  }
  removeFromStorage() {
    localStorage.removeItem("currentUser");
  }
}
