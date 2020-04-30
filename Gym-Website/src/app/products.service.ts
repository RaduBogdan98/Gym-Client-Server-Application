import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor() { }

  getProducts() {
    return [
      {name: 'Whey Protein', producer: 'Producer', description: 'Description', price: '2.00', image: 'protein.jpg'},
      {name: 'Dumbell Set', producer: 'Producer', description: 'Description', price: '12.00', image: 'dumbell.jpg'},
      {name: 'Fitness dumbells set', producer: 'Producer', description: 'Description', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness dumbells set', producer: 'Producer', description: 'Description', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness Band', producer: 'Producer', description: 'Description', price: '2.00', image: 'fitnessBand.jpg'},
      {name: 'Whey Protein', producer: 'Producer', description: 'Description', price: '2.00', image: 'protein.jpg'},
      
    ];
  }
}
