import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import HMO from "../model/HmoDto";

@Injectable({
    providedIn: 'root'
  })
  export class HMOService {
  
    constructor(public http: HttpClient) {  }
    baseRouteUrl = `${environment.baseUrl}/Hmo`
   
    getAllHMOs() {
      return this.http.get<HMO[]>(`${this.baseRouteUrl}`);
    }
  }
  