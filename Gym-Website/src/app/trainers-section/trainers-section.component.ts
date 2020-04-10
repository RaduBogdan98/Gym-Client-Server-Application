import { Component, OnInit} from '@angular/core';
import { TrainerService } from '../trainer.service';

@Component({
  selector: 'trainers-section',
  templateUrl: './trainers-section.component.html',
  styleUrls: ['./trainers-section.component.css']
})
export class TrainersSectionComponent implements OnInit {

  trainers_data;

  constructor(service: TrainerService) {
      this.trainers_data=service.getTrainersData();
   }

  ngOnInit(): void {
  }
}
