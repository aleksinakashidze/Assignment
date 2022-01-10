

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Market } from '../Market/Market';


@Injectable({
    providedIn: 'root'
  })
  export class marketService {
  
    url = 'https://localhost:44392/api/Market/';
    constructor(private http: HttpClient) { }
    getProductList() {
      return this.http.get<Market[]>(this.url + 'List');
    }
    postProductData(productData: Market): Observable<Market> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<Market>(this.url + 'CreateRecord', productData, httpHeaders);
    }
    updateProduct(product: Market): Observable<Market> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<Market>(this.url + 'UpdateProduct?id=' + product.marketID, product, httpHeaders);
    }
    deleteProductById(id: number): Observable<number> {
      return this.http.post<number>(this.url + 'DeleteProduct?id=' + id, null);
    }
    getProductDetailsById(id: number): Observable<Market> {
      return this.http.get<Market>(this.url + 'Details?id=' + id);
    }
  }