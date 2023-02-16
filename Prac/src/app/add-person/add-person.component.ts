import { Component, OnInit } from '@angular/core';
import Person from '../model/Person';
import { UserService } from '../userService';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HMOService } from '../services/HMO.service';
import HMO from '../model/HmoDto';
import { PersonsService } from '../services/Persons.service';
import FatherAndChild from '../model/FatherAndChild';
import { FatherAndChildService } from '../services/FatherAndChild.service';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.scss']
})
export class AddPersonComponent implements OnInit {

  //varriables
  fileName = 'ExcelSheet.xlsx';
  HMOs: HMO[]
  children: Person[] = []
  person: Person
  personFromServer: Person
  idFather: number
  idMother: number
  idChild: number
  hmoId: number
  isFirstChild: boolean = true;
  date: Date
  pattern = '[0-9]{9}'
  newForService = { FirstName: "", LastName: "" }//אוביקט לשמירה ב LOCAL STORAGE

  constructor(public userService: UserService, public hmoService: HMOService,
    public personService: PersonsService, public fatherAndChildService: FatherAndChildService,public action: Router) { }

  ngOnInit(): void {
    //הבאת רשימת קופות החולים
    try {
      this.hmoService.getAllHMOs().subscribe(ok => {
        this.HMOs = ok
        console.log(this.HMOs);
      });
    } catch (Error) {
      alert("התרחשה שגיאה בהתחברות לשרת")
    }
    //אתחול השדות בנתונים אחרונים מה LOCAL STORAGE
    if (this.userService.getStorage() == "")
      this.person = new Person(0, "", "", 0, "", null, false)
    else this.person = this.userService.getStorage();
  }
  ngOnDestroy(): void {
    this.newForService.FirstName = this.person.firstName;
    this.newForService.LastName = this.person.lastName;
    this.userService.newPerson.next(this.newForService)
    this.userService.saveStorage(this.person)
  }
  //functions
  refreshForm() {
    this.person.firstName = "";
    this.person.lastName = "";
    this.person.dateOfBirth = null;
    this.person.idNumber = "";
    this.person.maleOrFemale = false;
    this.person.hmoid = 0
    this.children=[]
    this.isFirstChild = true
  }
  addPersonToServer() {
    //הוספה לשרת
    // else{
    try {
      console.log(this.personFromServer);
      this.personService.addNewPerson(this.person).subscribe(ok => {
        this.personFromServer = ok;
        if (this.personFromServer.maleOrFemale)
          this.idFather = this.personFromServer.personId
        else
          this.idMother = this.personFromServer.personId
        console.log(this.personFromServer);
        console.log(this.idChild);
        console.log(this.idMother);
      });
    }
    catch (Error) {
      alert("התרחשה שגיאה בהתחברות לשרת")
    }
    // }
  }
  addChild() {
    this.person.dateOfBirth = this.date
    if (this.isFirstChild) {
      this.addPersonToServer();
      this.isFirstChild = false
    }
    this.children.push(new Person(0, "", "", 0, "", null, false))
  }
  regist() {
    console.log("hgfds");
    for (let index = 0; index < this.children.length; index++) {
     
      // הוספת ילד לשרת
      try {
        this.personService.addNewPerson(this.children[index]).subscribe(ok => {
          this.personFromServer = ok;
          this.idChild = this.personFromServer.personId
        });
      }
      catch (Error) {
        alert("התרחשה שגיאה בהתחברות לשרת")
      }
     
 //עדכון האבא בשרת
      // if (this.personFromServer) {
      // try {
      //   this.personService.updatePerson(this.children[index].person).subscribe(ok => {
      //     this.personFromServer = ok;
      // this.idChild = this.personFromServer.personId
      //     console.log(this.personFromServer);
      //   });
      // } catch (Error) {
      //   alert("התרחשה שגיאה בהתחברות לשרת")
      // }
      //הוספת הקשר הורה- בן
      try {
        this.fatherAndChildService.FatherAndChildPost(new FatherAndChild(this.idChild, this.idFather, this.idMother)).subscribe(ok => {
          console.log(index + "succ");
        });
      }
      catch (Error) {
        alert("התרחשה שגיאה בהתחברות לשרת")
      }
      //הסרת אוביקטים מה LOCALSTORAGE
      this.userService.removeStorage();
      //אתחול נתונים למילוי טופס חדש
      this.refreshForm()
      this.action.navigate(["end"])
    }






  }
  hmoidFunction(hmoid: number) {

    for (let index = 0; index < this.HMOs?.length; index++) {
      if (this.HMOs[index].hmoid == hmoid)
        return this.HMOs[index].hmoname
    }
    return ""
  }
  maleOrFemaleFunction(maleOrFemale: Boolean) {
    return maleOrFemale == true ? "male" : "female"

  }
  exportexcel(): void {
    /* pass here the table id */
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, this.fileName);
  }
}

