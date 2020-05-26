import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Model/Product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private BASE_URL = "http://localhost:8080";
  private ALL_PRODUCTS_URL = `${this.BASE_URL}/products/all`;

  constructor(private http : HttpClient) { }

  getProducts() : Observable<Product[]> {
    return this.http.get<Product[]>(this.ALL_PRODUCTS_URL);
  }
}
