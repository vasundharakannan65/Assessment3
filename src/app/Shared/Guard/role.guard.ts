import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {


  constructor(private authService : AuthService) { 
  }
         
  jwtHelper = new JwtHelperService();
  
  canActivate()
  {    
    //debugger
    const token = localStorage.getItem("AccessToken");
    const decodedToken = this.jwtHelper.decodeToken(token?.toString());

    let Role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    localStorage.setItem('UserType',Role);

    if(Role == "Administrator")
    {
      return true;
    }
    else
    {
      return false;
    }
  }
   
}
