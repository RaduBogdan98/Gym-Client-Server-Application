export class OrderItem{
    image:string;
    name:string;
    price:string;
    quantity:string;

    constructor( image:string, name:string, price:string, quantity:string){
        this.image=image;
        this.name=name;
        this.price=price;
        this.quantity=quantity
    }
}