import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';
import { Product } from '../Model/Product';

@Component({
  selector: 'product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.css']
})
export class ProductGridComponent implements OnInit {
  products: Product[];

  constructor(service: ProductsService) 
  { 
    this.products=service.getProducts();
  }

  ngOnInit(): void {
  }

}
