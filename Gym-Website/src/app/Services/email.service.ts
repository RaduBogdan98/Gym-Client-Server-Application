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
    let message = "Hi there!<br/><br/>We are really happy to have you on board and we are looking forward to a healthy partnership!<br/><br/>Our best regards!<br/>FitNess Team";
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
      let message = "Hi! Your order has been processed! We will send you order as soon as possible!<br/><br/> Order contents:<br/>";
      o.orderContent.forEach((item:OrderItem)=>
      {
          message += "&emsp;" + item.product.name + " of price " + item.product.price + "$ x " + item.quantity + "<br/>";
      });
      message += "<br/>&emsp;Total Price: " + o.totalPrice+"$<br/><br/>Thank you for ordering from us!<br/>FitNess Team";

      return message;
  }
}
