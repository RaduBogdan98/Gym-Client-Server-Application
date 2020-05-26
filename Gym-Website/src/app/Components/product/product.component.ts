import { Component, OnInit, Attribute, Input } from '@angular/core';
import { MessengerService } from '../../Services/messenger.service';
import { Product } from '../../Model/Product';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() name:string;
  @Input() description:string;
  @Input() image:string;
  @Input() price:number;

  constructor(@Attribute('name')name:string, @Attribute('description')description:string, 
              @Attribute("price")price:number, @Attribute('image')image:string,
              private messengerService: MessengerService)
  {
    this.name=name;
    this.description=description;
    this.image=image;
    this.price=price;
  }

  ngOnInit(): void {
  }

  addToCart(){
    let myProduct = new Product(this.name, this.price, 0, this.description, this.image);
    this.messengerService.sendProduct(myProduct);
  }
}
