import { Component, OnInit } from '@angular/core';
import { CartItem } from '../../Model/CartItem';
import { OrdersService } from '../../Services/orders.service';
import { MessengerService } from '../../Services/messenger.service';
import { Product } from '../../Model/Product';
import { Order } from '../../Model/Order';
import { User } from '../../Model/User';
import { OrderItem } from '../../Model/OrderItem';

@Component({
  selector: 'shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent implements OnInit {
  cartItems: CartItem[] = [];
  cartTotal = 0;
  user: User;

  constructor(private ordersService: OrdersService, private messengerService:MessengerService) {
    this.user = null;
  }

  ngOnInit(): void 
  {
    this.messengerService.getUser().subscribe( (user:User) =>
    {
      this.user = user;
    });

    this.messengerService.getProduct().subscribe( (product:Product) =>
    {
      this.addProductToCart(product);
    });

    this.messengerService.getOrderItem().subscribe((itemToRemove:CartItem) =>
    {     
      for(let i=0;i<this.cartItems.length; i++){
        if(this.cartItems[i].name == itemToRemove.name){
          this.cartItems.splice(i,1);
          break;
        }
      }

      this.calculateCartTotal();
    });
  }

  addProductToCart(product:Product)
  {
    let newItem = null;
    this.cartItems.forEach(item=>
      {
        if(item.name == product.name){
          newItem = item;
      }
    })

    if(newItem == null)
    {
      newItem = new CartItem(product.image, product.name,product.price,1);
      this.cartItems.push(newItem);
    }
    else
    {
      newItem.quantity += 1;
    }

    this.calculateCartTotal();
  }

  calculateCartTotal()
  {
    this.cartTotal = 0;
    this.cartItems.forEach(item=>
    {
      this.cartTotal += (item.quantity * item.price);
    });
  }

  sendOrder(){
    if(this.user!=null){
      let order = new Order([], this.user, this.cartTotal);

      this.cartItems.forEach(item=>
      {
        let orderItem = new OrderItem(new Product(item.name, item.price, 0, '', item.image),item.quantity);
        order.orderContent.push(orderItem);
      })
  
      this.ordersService.sendOrder(order).subscribe(
        res=>{
          if(res!=null){
            this.cartItems = [];
            this.cartTotal = 0;

            alert('Your order was posted!');
          }
          else{
            alert('Your order post failed!');
          }
        },
        err=>{
          alert('Server error!');
        }
      );
    }
    else{
      alert('Please login!');
    }
  }
}