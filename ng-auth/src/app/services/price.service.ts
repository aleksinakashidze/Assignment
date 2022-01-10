

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Products } from '../products/Product';
import { price } from '../Price/Price';
import { Market } from '../Market/Market';


@Injectable({
    providedIn: 'root'
  })
  export class PriceService {
  
    url = 'https://localhost:44392/api/Price/';
    urlproduct='https://localhost:44392/api/Product/';
    urlmarket='https://localhost:44392/api/Market/';
    constructor(private http: HttpClient) { }

    getProductList() {
      return this.http.get<Products[]>(this.urlproduct + 'List');
    }
    getMarketList() {
      return this.http.get<Market[]>(this.urlmarket + 'List');
    }
    getPriceList() {
      return this.http.get<price[]>(this.url + 'List');
    }
    postProductData(productData: price): Observable<price> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<price>(this.url + 'CreateRecord', productData, httpHeaders);
    }
    updateProduct(product: price): Observable<price> {
      const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
      return this.http.post<price>(this.url + 'UpdateProduct?id=' + product.productID, product, httpHeaders);
    }
    deleteProductById(id: number): Observable<number> {
      return this.http.post<number>(this.url + 'DeleteProduct?id=' + id, null);
    }
    getProductDetailsById(id: number): Observable<price> {
      return this.http.get<price>(this.url + 'Details?id=' + id);
    }
  }