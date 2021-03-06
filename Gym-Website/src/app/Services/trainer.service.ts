import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TrainerService {

  constructor() {}

  getTrainersData(){
    
    return [
      {name: 'Farcas Rares', description: 'Personal trainer, Group fitness manager', image_src: 'rares.jpg'},
      {name: 'Imre Andreea', description: 'Yoga teacher, Personal trainer, Group fitness', image_src: 'andreea.jpg'},
      {name: 'Gabos Monica', description: 'Cycling instructor, Personal trainer', image_src: 'monica.jpg'},
      {name: 'Balint Zoltan', description: 'Personal Trainer, Group Fitness, Aerobic Instructor', image_src: 'zoltan.jpg'}
    ];
  }
}
