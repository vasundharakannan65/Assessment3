import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-add-product-image-dialog',
  templateUrl: './add-product-image-dialog.component.html',
  styleUrls: ['./add-product-image-dialog.component.css']
})
export class AddProductImageDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AddProductImageDialogComponent>,
    private productService : ProductService) { }

  fileAttr = 'Choose File';

  data = {
    file : '',
    productId : 0
  }

  
  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onImageUpload() {
    const datas = {
      File : this.data.file,
      ProductId : this.data.productId
    }; 
    this.productService.AddImage(datas).subscribe((data)=>{
      console.log('Successfully Added Image!',datas);
    })
  }

}
