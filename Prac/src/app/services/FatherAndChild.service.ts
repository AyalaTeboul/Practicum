import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import FatherAndChild from "../model/FatherAndChild";

@Injectable({
    providedIn: 'root'
  })
  export class FatherAndChildService {
   
    constructor(public http: HttpClient) {  }
    baseRouteUrl = `${environment.baseUrl}/FatherAndChild`
   
    FatherAndChildPost(fatherAndChild:FatherAndChild):Observable<FatherAndChildService> {
      return this.http.post<FatherAndChildService>(`${this.baseRouteUrl}`,fatherAndChild);
    }
  }
  