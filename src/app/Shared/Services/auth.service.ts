import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) { }

  public LogIn(data: any):Observable<any>{
    console.log("Method calling");
    return this.http.post(`${baseUrl}Account/Login`,data);
  } 

  public IsLoggedIn(){
    return !!localStorage.getItem('AccessToken');
  } 

  
}
