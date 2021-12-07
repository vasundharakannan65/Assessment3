import { Component, OnInit } from '@angular/core';
import { RoleGuard } from 'src/app/Shared/Guard/role.guard';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private roleGuard : RoleGuard) { }

  ngOnInit(): void {
    this.IsAllowed();
  }

  IsVisible !: boolean 

  public IsAllowed() {

    debugger
    console.log(this.roleGuard.canActivate())

    if(this.roleGuard.canActivate()) 
    {
        this.IsVisible = true;
    } 
    else 
    {
       this.IsVisible = false;
    }

  }

}
