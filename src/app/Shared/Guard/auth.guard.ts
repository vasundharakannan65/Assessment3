import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService : AuthService,
              private router : Router) { }
  
  canActivate() {

    //debugger
    if(this.authService.IsLoggedIn()){
      return true;
    }
    
    alert("you have not logged In!")
    this.router.navigate(['login']);    
    return false;    
  }
  
}
