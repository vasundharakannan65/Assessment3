import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListOfProductsComponent } from './list-of-products/list-of-products.component';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { RoleGuard } from 'src/app/Shared/Guard/role.guard';
import { FormsModule } from '@angular/forms';
import { AddProductImageDialogComponent } from './add-product-image-dialog/add-product-image-dialog.component';


const routes: Routes = [
  { path: 'list',component:ListOfProductsComponent,
  canActivate:[RoleGuard]},
  { path: 'add',component:AddProductComponent,
  canActivate:[RoleGuard]}
];

@NgModule({
  declarations: [
    ListOfProductsComponent,
    AddProductComponent,
    AddProductImageDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ]
})

export class ProductsModule { }
