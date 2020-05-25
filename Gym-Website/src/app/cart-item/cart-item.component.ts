import { Component, OnInit, Input, Attribute } from '@angular/core';

@Component({
  selector: 'cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  @Input() name:string
  @Input() quantity:string
  @Input() image:string
  @Input() price:string

  constructor(@Attribute('name')name:string, @Attribute('quantity')quantity:string, 
              @Attribute('price')price:string, @Attribute('image')image:string)
  {
    this.name=name;
    this.quantity=quantity;
    this.image=image;
    this.price=price;
  }


  ngOnInit(): void {
  }
}
