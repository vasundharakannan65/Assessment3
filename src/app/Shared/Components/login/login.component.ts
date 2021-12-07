import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RoleGuard } from '../../Guard/role.guard';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private fb: FormBuilder,
              private authService : AuthService,
              private router : Router,
              private roleGuard : RoleGuard) { }

  loginForm !: FormGroup;
  submitted = false;
  hide = true;

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', Validators.compose([Validators.required])]
    });
  }

  get loginFormControl() {
    return this.loginForm.controls;
  }

  onSubmit() {
    debugger
    this.submitted = true;
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.authService.LogIn(this.loginForm.value).subscribe(result => {
        if(result) {
          localStorage.setItem('AccessToken',result.token);
          alert('LoggedIn Successfully!');
          if(this.roleGuard.canActivate())
          {
            this.router.navigateByUrl('products');
          }
          else 
          {
            this.router.navigateByUrl('listOfProducts');
          }
        }
        else {
          alert(result.message);
        }
      })
    }
  }

}
