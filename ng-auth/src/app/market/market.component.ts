import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { marketService } from '../services/market.service';

import { Market } from './Market';

@Component({
  selector: 'market',
  templateUrl: './market.component.html',
  styleUrls: ['./marketStyle.css']
})
export class MarketComponent implements OnInit {

  ProductList: Market[];
  ProductList1: Observable<Market[]>;
  productForm: any;
  massage = "";
  prodCategory = "";
  productId = 0;
  constructor( private formbulider: FormBuilder, private httpClient: HttpClient, private productService:marketService ) { }

  ngOnInit() {
    this.prodCategory = "0";
    this.productForm = this.formbulider.group({
      marketName: ['', [Validators.required]],
     
    });


    this.getProductList();
  }
  getProductList() {
     this.productService.getProductList().subscribe(x=>{
       this.ProductList=x;
     });
    
  }
  PostProduct(product: Market) {
    const product_Master = this.productForm.value;
    this.productService.postProductData(product_Master).subscribe(
      () => {
        this.massage = 'Data Saved Successfully';
        this.getProductList();
      }
    );
  }
  ProductDetailsToEdit(id: number) {
    this.productService.getProductDetailsById(id).subscribe(productResult => {
      this.productId = productResult.marketID;
      this.productForm.controls['marketName'].setValue(productResult.marketName);
    });
  }
  UpdateProduct(product: Market) {
    product.marketID = this.productId;
    const product_Master = this.productForm.value;
    this.productService.updateProduct(product_Master).subscribe(() => {
      this.massage = 'Record Updated Successfully';
      this.getProductList();
    });
  }
  DeleteProduct(id: number) {
    if (confirm('Do you want to delete this product?')) {
      this.productService.deleteProductById(id).subscribe(() => {
        this.getProductList();
      });
    }
  }
  onSubmit() {
    
    this.productForm.reset();
      
    
  }
 
}





