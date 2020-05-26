import { OrderItem } from './OrderItem';
import { User } from './User';

export class Order
{
    orderDate:string;
    orderContent:OrderItem[];
    totalPrice:number;
    user:User;

    constructor(orderContent:OrderItem[], user: User, totalPrice:number)
    {
        this.orderContent = orderContent;
        this.orderDate = new Date().toLocaleString().split(',')[0];
        this.totalPrice = totalPrice;
        this.user = user;
    }
}