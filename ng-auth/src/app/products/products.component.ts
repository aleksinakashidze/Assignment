import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Products } from './Product';


@Component({
  selector: 'product',
  templateUrl: './products.component.html',
  styleUrls: ['./productStyle.css']

  
  
})
export class ProductComponent implements OnInit {

  ProductList: Products[];
  ProductList1: Observable<Products[]>;
  productForm: any;
  massage = "";
  prodCategory = "";
  productId = 0;
  constructor(private formbulider: FormBuilder, private httpClient: HttpClient, private productService:ProductService ) { }

  ngOnInit() {
    this.prodCategory = "0";
    this.productForm = this.formbulider.group({
      productName: ['', [Validators.required]],
     
    });


    this.getProductList();
  }
  getProductList() {
     this.productService.getProductList().subscribe(x=>{
       this.ProductList=x;
     });
    
  }
  PostProduct(product: Products) {
   
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
      this.productId = productResult.productID;
      this.productForm.controls['productName'].setValue(productResult.productName);
    });
  }
  UpdateProduct(product: Products) {
   
    product.productID = this.productId;
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