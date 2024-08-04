
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";


import { LoginComponent } from './login/login.component';

import { AppComponent } from './app.component';
import { ProductComponent } from './products/products.component';
import { MarketComponent } from './market/market.component';
// import { PriceComponent } from './Price/Price.component';
import { AuthGuard } from './guards/auth-guard.service';
import { PriceComponent } from './Price/price.component';


export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
   
    LoginComponent,
 
    AppComponent,
    ProductComponent,
    MarketComponent,
    PriceComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
     
      { path: '', component: LoginComponent },
     { path: 'products', component: ProductComponent, canActivate: [AuthGuard] },
     { path: 'market', component: MarketComponent, canActivate: [AuthGuard] },
     { path: 'price', component: PriceComponent, canActivate: [AuthGuard] },
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44392"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
