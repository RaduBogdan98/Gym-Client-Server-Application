import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../Services/products.service';
import { Product } from '../../Model/Product';

@Component({
  selector: 'product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.css']
})
export class ProductGridComponent implements OnInit {
  products: Product[];

  constructor(private service: ProductsService) {}

  ngOnInit(): void {
    this.service.getProducts().subscribe(
      res => {
        this.products=res;
      },
      err => {
        alert('Server error!');
      }
    );
  }

}