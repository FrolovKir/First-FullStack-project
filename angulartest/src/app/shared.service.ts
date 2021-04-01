import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="http://localhost:53850/api";

  constructor(private http:HttpClient) { }

  


  getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employer');
  }

  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Employer',val);
  }

  updateEmployee(val:any){
    return this.http.put(this.APIUrl+'/Employer',val);
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Employer/'+val);
  }


  getAllEmployersNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Employer/GetAllEmployerNames');
  }

}
