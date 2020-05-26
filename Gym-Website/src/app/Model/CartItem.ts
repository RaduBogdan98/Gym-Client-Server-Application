export class CartItem{
    image:string;
    name:string;
    price:number;
    quantity:number;

    constructor( image:string, name:string, price:number, quantity:number){
        this.image=image
        this.name=name
        this.price=price
        this.quantity=quantity
    }
}