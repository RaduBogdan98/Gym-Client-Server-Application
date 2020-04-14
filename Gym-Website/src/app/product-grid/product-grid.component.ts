import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';

@Component({
  selector: 'product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.css']
})
export class ProductGridComponent implements OnInit {
  products: {
    name:string, 
    producer:string, 
    description:string, 
    price:string,
    image:string
  } [];

  constructor(service: ProductsService) 
  { 
    this.products=service.getProducts();
  }

  ngOnInit(): void {
  }

}
