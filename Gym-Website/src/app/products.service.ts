import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor() { }

  getProducts() {
    // Product  httpRequest(Response) 
    return [
      {name: 'Whey Protein', description: 'Description', price: '2.00', image: 'protein.jpg'},
      {name: 'Dumbell Set', description: 'Description', price: '12.00', image: 'dumbell.jpg'},
      {name: 'Fitness dumbells set',  description: 'Description', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness dumbells set',  description: 'Description', price: '100.00', image: 'smallDumbells.jpg'},
      {name: 'Fitness Band',description: 'Description', price: '2.00', image: 'fitnessBand.jpg'},
      {name: 'Whey Protein',  description: 'Description', price: '2.00', image: 'protein.jpg'},
      
    ];
  }
}
