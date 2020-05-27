import { Injectable } from '@angular/core';
import { Order } from '../Model/Order';
import { OrderItem } from '../Model/OrderItem';
import { User } from '../Model/User';
import { EmailItem } from '../Model/EmailItem';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  private BASE_URL = "http://localhost:80/Emailer/emailer.php";

  constructor(private http:HttpClient) { }

  sendEmailOnSignUp(user:User){
    let message = "Hi there!\n\nWe are really happy to have you on board and we are looking forward to a healthy partnership!\n\nOur best regards!\nFitNess Team";
    let email = new EmailItem(user.email, "support@fitness.com", "Welcome to our team " + user.username, message);

    return this.http.post(this.BASE_URL, email).subscribe();
  }

  sendEmailForOrder(order:Order){
    let message =this.buildOrderEmailMessage(order);
    let email = new EmailItem(order.user.email, "support@fitness.com", "Order Confirmation", message);

    return this.http.post(this.BASE_URL, email).subscribe();
  }

  buildOrderEmailMessage(o:Order):string
  {
      let message = "Your order containing:\n";
      o.orderContent.forEach((item:OrderItem)=>
      {
          message += "\t" + item.product.name + " of price " + item.product.price + "$ x " + item.quantity + "\n";
      });
      message += "\n\tTotal Price: " + o.totalPrice+"\n\nThank you for ordering from us!\nFitNess Team";

      return message;
  }
}
