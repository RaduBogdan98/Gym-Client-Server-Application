import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon' 
import {MatSidenavModule} from '@angular/material/sidenav'; 
import {MatCardModule} from '@angular/material/card'; 
import {MatGridListModule} from '@angular/material/grid-list'; 
import {MatListModule} from '@angular/material/list';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './Components/menu/menu.component';
import { TrainerProfileComponent } from './Components/trainer-profile/trainer-profile.component';
import { TrainerService } from './Services/trainer.service';
import { TrainersSectionComponent } from './Components/trainers-section/trainers-section.component';
import { ProductComponent } from './Components/product/product.component';
import { ProductGridComponent } from './Components/product-grid/product-grid.component';
import { ProductsService } from './Services/products.service';
import { SlideShowComponent } from './Components/slide-show/slide-show.component';
import { SubscriptionsComponent } from './Components/subscriptions/subscriptions.component';
import { AboutusComponent } from './Components/aboutus/aboutus.component';
import { ContactComponent } from './Components/contact/contact.component';
import { LoginComponent } from './Components/login/login.component';
import { RouterModule } from '@angular/router';
import { ShoppingcartComponent } from './Components/shoppingcart/shoppingcart.component';
import { CartItemComponent } from './Components/cart-item/cart-item.component'
import { OrdersService } from './Services/orders.service';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './Services/login.service';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    TrainerProfileComponent,
    TrainersSectionComponent,
    ProductComponent,
    ProductGridComponent,
    SlideShowComponent,
    SubscriptionsComponent,
    AboutusComponent,
    ContactComponent,
    LoginComponent,
    CartItemComponent,
    ShoppingcartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatCardModule,
    MatListModule,
    MatGridListModule,
  ],
  providers: [
    TrainerService,
    ProductsService,
    OrdersService,
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }