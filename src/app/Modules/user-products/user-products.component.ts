import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-user-products',
  templateUrl: './user-products.component.html',
  styleUrls: ['./user-products.component.css']
})
export class UserProductsComponent implements OnInit {

  products: any = [];

  constructor(private productService : ProductService) { }
  
  ngOnInit(): void {
    this.GetAllProducts();
  }

  // Getting list of products
  public GetAllProducts() : void {
    debugger
    this.productService.GetListOfProducts().subscribe((products: any) => {this.products = products;},(error: any) => 
    {
      console.log(error);
    });
  }
}
