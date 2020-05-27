import { Injectable } from '@angular/core';
import { Subject } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  constructor() { }

  //#region ProductSubject
  productSubject = new Subject();

  sendProduct(product)
  {
    this.productSubject.next(product); //Trigger product sending event
  }

  getProduct()
  {
    return this.productSubject.asObservable();
  }
  //#endregion

  //#region OrderItemSubject
  orderItemSubject = new Subject();

  sendOrderItem(orderItem)
  {
    this.orderItemSubject.next(orderItem); //Trigger order item removal event
  }

  getOrderItem()
  {
    return this.orderItemSubject.asObservable();
  }
  //#endregion

  //#region OrderItemQuantitySubject
  orderItemQuantitySubject = new Subject();

  sendOrderItemQuantity(orderItem)
  {
    this.orderItemQuantitySubject.next(orderItem); //Trigger order item quantity change event
  }

  getOrderItemQuantity()
  {
    return this.orderItemQuantitySubject.asObservable();
  }
  //#endregion

  //#region UserSubject
  userSubject = new Subject();

  sendUser(user){
    this.userSubject.next(user); //Trigger on user login/signUp
  }

  getUser(){
    return this.userSubject.asObservable();
  }
  //#endregion

  //#region LoginInteractionService
  loginService = new Subject();

  sendLoginState(state){
    this.loginService.next(state);
  }

  getLoginState(){
    return this.loginService.asObservable();
  }
  //#endregion
}
