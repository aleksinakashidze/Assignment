import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Market } from '../Market/Market';
import { Products } from '../products/Product';
import { PriceService } from '../services/price.service';
import { price } from './Price';
import { priceList } from './priceList';
@Component({
  selector: 'Price',
  templateUrl: './price.component.html',
  styleUrls: ['./priceStyle.css']
})
export class PriceComponent implements OnInit {
  
  PriceList: priceList[]  | null;
  productList: Products[];
  MarketList: Market[];
  productList1: priceList[];
  price: price[];
  productForm: any;
  massage = "";
  prodCategory = "";
  productId = 0;
  arr : string[]; 
  id:any;
  constructor(private formbulider: FormBuilder, private httpClient: HttpClient, private productService:PriceService ) { }
  ngOnInit() {
    this.prodCategory = "0";
    this.productForm = this.formbulider.group({
      productID: [''],
      marketID: [''],
      price: ['',Validators.required],
      
      
    });
    this.getProductList();
    this.getMarketList();
    this.getPriceData();
   
  }
  getProductList() {
    this.productService.getProductList().subscribe(x=>{
      this.productList=x;
    });
 }
 
 getMarketList() {
 
  this.productService.getMarketList().subscribe(x=>{
  
    this.MarketList=x;
  });
  }
  getPriceData() {
    this.getProductList();
    this.getMarketList();
     this.productService.getPriceList().subscribe(x=>{
    
       
       this.price=x;
       let customObj1= new priceList;
       let customObj= [new priceList];
     for(var i = 0; i <  x.length; i++){
       
      customObj1.priceID=x[i].priceID;
      customObj1.productID=x[i].productID;
      customObj1.marketID=x[i].marketID;
      customObj1.productName=this.productList.find(m=>m.productID==this.price[i].productID).productName;
      customObj1.marketName=this.MarketList.find(l=>l.marketID==this.price[i].marketID).marketName;
      customObj1.price=x[i].price;
      customObj.push(Object.assign({ }, customObj1));
    }
    this.PriceList=customObj .filter( obj => !(obj && Object.keys(obj).length === 0));
    
     });
     
  }
  PostProduct(product: price) {
    const product_Master = this.productForm.value;
    this.productService.postProductData(product_Master).subscribe(
      () => {
        this.massage = 'Data Saved Successfully';
        this.getPriceData();
      }
     
    );
  }
  ProductDetailsToEdit(id: number) {
  
    this.productService.getProductDetailsById(id).subscribe(productResult => {
      this.productId = productResult.priceID;
      this.productForm.controls['productID'].setValue(productResult.productID);
      this.productForm.controls['marketID'].setValue(productResult.marketID);
      this.productForm.controls['price'].setValue(productResult.price);
      
      
    });
  }
  UpdatePro(product: price) {
   

    console.log("1");
    product.priceID = this.productId;
    let product_Master = this.productForm.value;
    let racxa:any;
    let counter:number = 0;
      this.productService.updateProduct(product_Master).subscribe((data) => {
        this.massage = 'Record Updated Successfully';
         racxa = setInterval(() => {  
          if(counter == 1){
            clearInterval(racxa);
          }
          counter++;
        this.getPriceData();
      }, 5000);
     
      });
  
    this.onSubmit();
   
  }
  DeleteProduct(id: number) {
    if (confirm('Do you want to delete this product?')) {
      this.productService.deleteProductById(id).subscribe(() => {
        this.getPriceData();
      });
    }
  }
  onSubmit() {
    this.productForm.reset();
  }
  
}