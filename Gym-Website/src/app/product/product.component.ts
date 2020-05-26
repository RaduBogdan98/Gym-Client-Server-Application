import { Component, OnInit, Attribute, Input } from '@angular/core';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() name:string;
  @Input() description:string;
  @Input() image:string;
 
  @Input() price:string;

  constructor(@Attribute('name')name:string, @Attribute('description')description:string, 
              @Attribute("price")price:string, @Attribute('image')image:string)
  {
    this.name=name;
    this.description=description;
    this.image=image;
    
    this.price=price;
  }

  ngOnInit(): void {
  }

}
