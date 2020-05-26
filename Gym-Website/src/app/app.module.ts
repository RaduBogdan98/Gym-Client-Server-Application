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
import { MenuComponent } from './menu/menu.component';
import { TrainerProfileComponent } from './trainer-profile/trainer-profile.component';
import { TrainerService } from './trainer.service';
import { TrainersSectionComponent } from './trainers-section/trainers-section.component';
import { ProductComponent } from './product/product.component';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { ProductsService } from './products.service';
import { SlideShowComponent } from './slide-show/slide-show.component';
import { SubscriptionsComponent } from './subscriptions/subscriptions.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';
import { CartItemComponent } from './cart-item/cart-item.component'
import { OrdersService } from './orders.service';

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
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatCardModule,
    MatListModule,
    MatGridListModule,
    RouterModule.forRoot([
      { path: 'login',
        component: LoginComponent
      } ,
      {
        path: 'shoppingcart',
        component: ShoppingcartComponent
      }
      
    ])
  ],
  providers: [
    TrainerService,
    ProductsService,
    OrdersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }