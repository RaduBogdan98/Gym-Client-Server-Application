export class Product{
    name:string;
    description:string;
    image:string;
    price:string;

    constructor( image:string, name:string, price:string, description:string){
        this.image=image;
        this.name=name;
        this.price=price;
        this.description=description
    }
}