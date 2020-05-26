export class Product{
    name:string;
    description:string;
    image:string;
    price:number;
    stock:number;

    constructor( name:string, price:number, stock:number, description:string, image:string){
        this.image=image;
        this.name=name;
        this.price=price;
        this.description=description
        this.stock = stock;
    }
}