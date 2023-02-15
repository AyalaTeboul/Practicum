import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import Person from "../model/Person";

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  constructor(public http: HttpClient) { }
  baseRouteUrl = `${environment.baseUrl}/Person`

getAllPersons():Observable<Person[]>{
  return this.http.get<Person[]>(`${this.baseRouteUrl}`)
}

  addNewPerson(per: Person): Observable<Person> {
    const newPer = {
      firstName: per.firstName,
      lastName: per.lastName,
      hmoid: per.hmoid,
      idNumber: per.idNumber,
      dateOfBirth: per.dateOfBirth,
      maleOrFemale: per.maleOrFemale
    }
    return this.http.post<Person>(`${this.baseRouteUrl}`, newPer)
  }
  getPersonByIdNumber(idNumber: string) {

    return this.http.get<Person>(`${this.baseRouteUrl}/${idNumber}`)
  }
  updatePerson(per: Person): Observable<Person> {
    const jsonPerson = JSON.parse(JSON.stringify(per));
    const params = new HttpParams({
      fromObject: jsonPerson,
    });
    return this.http.put<Person>(`${this.baseRouteUrl}/${per.idNumber}/${per.maleOrFemale}/${per.hmoid}`, params)
  }
}
