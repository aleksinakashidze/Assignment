

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Products } from '../products/Product';


@Injectable({
    providedIn: 'root'
  })
  export class ProductService {
  
    url = 'https://localhost:44392/api/Product/';
    constructor(private http: HttpClient) { }
    getProductList() {
      return this.http.get<Products[]>(this.url + 'List');
    }
    postProductData(productData: Products): Observable<Products> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<Products>(this.url + 'CreateRecord', productData, httpHeaders);
    }
    updateProduct(product: Products): Observable<Products> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<Products>(this.url + 'UpdateProduct?id=' + product.productID, product, httpHeaders);
    }
    deleteProductById(id: number): Observable<number> {
      return this.http.post<number>(this.url + 'DeleteProduct?id=' + id, null);
    }
    getProductDetailsById(id: number): Observable<Products> {
      return this.http.get<Products>(this.url + 'Details?id=' + id);
    }
  }