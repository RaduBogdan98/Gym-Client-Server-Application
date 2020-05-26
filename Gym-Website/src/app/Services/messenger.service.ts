import { Injectable } from '@angular/core';
import { Subject } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  constructor() { }

  //ProductSubject
  productSubject = new Subject();

  sendProduct(product)
  {
    this.productSubject.next(product); //Trigger product sending event
  }

  getProduct()
  {
    return this.productSubject.asObservable();
  }

  //OrderItemSubject
  orderItemSubject = new Subject();

  sendOrderItem(orderItem)
  {
    this.orderItemSubject.next(orderItem); //Trigger order item removal event
  }

  getOrderItem()
  {
    return this.orderItemSubject.asObservable();
  }

  //UserSubject
  userSubject = new Subject();

  sendUser(user){
    this.userSubject.next(user); //Trigger on user login/signUp
  }

  getUser(){
    return this.userSubject.asObservable();
  }
}
