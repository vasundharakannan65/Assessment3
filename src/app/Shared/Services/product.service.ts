import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  list() {
    throw new Error('Method not implemented.');
  }

  constructor(private http : HttpClient) { }

  //Get all products
  public GetListOfProducts(): Observable<any> {
    return this.http.get(`${baseUrl}Admin/GetAllProducts`);
  }

  //Post product
  public CreateProduct(data:any): Observable<any> {
    return this.http.post(`${baseUrl}Admin/AddProduct`,data);
  }

  //Post Image
  public AddImage(data:any):Observable<any> {
    return this.http.post(`${baseUrl}Admin/AddProductImage`,data);
  }

}
