import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor() { }

  getItems() {
    return [
      {name: 'Whey Protein', quantity: '1', price: '2.00', image: 'protein.jpg'},
      {name: 'Dumbell Set', quantity: '2', price: '12.00', image: 'dumbell.jpg'},
      {name: 'Fitness dumbells set', quantity: '3', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness dumbells set', quantity: '4', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness Band', quantity: '6', price: '2.00', image: 'fitnessBand.jpg'},
      {name: 'Whey Protein', quantity: '5', price: '2.00', image: 'protein.jpg'},
      
    ];
  }
}
