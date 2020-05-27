import { Component, OnInit, Input, Attribute } from '@angular/core';
import { MessengerService } from '../../Services/messenger.service';
import { CartItem } from '../../Model/CartItem';

@Component({
  selector: 'cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  @Input() name:string
  @Input() quantity:number
  @Input() image:string
  @Input() price:number

  constructor(@Attribute('name')name:string, @Attribute('quantity')quantity:number, 
              @Attribute('price')price:number, @Attribute('image')image:string,
              private messengerService:MessengerService)
  {
    this.name=name;
    this.quantity=quantity;
    this.image=image;
    this.price=price;
  }


  ngOnInit(): void {
  }

  removeFromCart(){
    let myOrderItem = new CartItem(this.image, this.name, this.price, this.quantity);
    this.messengerService.sendOrderItem(myOrderItem);
  }

  onQuantityChange(quantityValue: string): void {  
    if(quantityValue!=""){
      this.quantity = Number.parseFloat(quantityValue);
      let myOrderItem = new CartItem(this.image, this.name, this.price, this.quantity);
      this.messengerService.sendOrderItemQuantity(myOrderItem);
    }
  }
}