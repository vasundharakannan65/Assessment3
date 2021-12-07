import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './Modules/products/products.component';
import { UserProductsComponent } from './Modules/user-products/user-products.component';
import { LoginComponent } from './Shared/Components/login/login.component';
import { AuthGuard } from './Shared/Guard/auth.guard';
import { RoleGuard } from './Shared/Guard/role.guard';

const routes: Routes = [
   { path: 'login', component: LoginComponent },

   { path: 'products', component: ProductsComponent,
     canActivate : [AuthGuard,RoleGuard],
     loadChildren: () => import('./Modules/products/products.module').then(m => m.ProductsModule) },

   { path: 'listOfProducts', component: UserProductsComponent,
     canActivate : [AuthGuard] },

   { path: '',   redirectTo: '/login', pathMatch: 'full' }, 

   { path: '**', redirectTo: '/login' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
