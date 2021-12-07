import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Shared/Models/Product';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(private productService : ProductService,
    ) { }

  ngOnInit(): void {
  }

  data = {
    name : ' ',
    categoryId : 0,
    brandId : 0,
    description : ' ',
    price : 0,
    stock : 0,
    expiryDate : ' ',
    discount : 0
  }

  addNewProduct() : void
  {   
    const datas = {
      Name : this.data.name,
      CategoryId : this.data.categoryId,
      BrandId : this.data.brandId,
      Description : this.data.description,
      Price : this.data.price,
      Stock : this.data.stock,
      Discount : this.data.discount,
      ExpiryDate : this.data.expiryDate,
    }; 

    this.productService.CreateProduct(datas).subscribe((data)=>{
      console.log('Successfully Added!',datas);
    })

    
  } 



}
