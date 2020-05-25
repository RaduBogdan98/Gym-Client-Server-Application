import { Component, OnInit } from '@angular/core';
import { OrderItem } from '../Model/OrderItem';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent implements OnInit {
  cartItems: OrderItem[];

  constructor(service: OrdersService) 
  { 
    this.cartItems=service.getItems();
  }

  ngOnInit(): void {
  }

}
