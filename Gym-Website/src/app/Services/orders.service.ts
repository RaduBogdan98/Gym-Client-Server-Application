import { Injectable, OnInit } from '@angular/core';
import { Order } from '../Model/Order';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private BASE_URL = "http://localhost:8080";
  private POST_ORDER_URL = `${this.BASE_URL}/orders/add`;

  constructor(private http : HttpClient) { }

  sendOrder(order: Order): Observable<any>{
    return this.http.post(this.POST_ORDER_URL, order);
  }
}