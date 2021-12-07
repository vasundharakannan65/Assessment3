import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProductService } from 'src/app/Shared/Services/product.service';
import { AddProductImageDialogComponent } from '../add-product-image-dialog/add-product-image-dialog.component';

@Component({
  selector: 'app-list-of-products',
  templateUrl: './list-of-products.component.html',
  styleUrls: ['./list-of-products.component.css']
})
export class ListOfProductsComponent implements OnInit {
  products: any = [];

  constructor(private productService : ProductService,
    public dialog: MatDialog) { }

    openDialog(event: MouseEvent): void {
      console.log(event);
      const dialogRef = this.dialog.open(AddProductImageDialogComponent, {
        width: '450px',
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');

      });
    }
  

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
