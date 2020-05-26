import { Component, Input } from '@angular/core';
import { TrainerService } from './Services/trainer.service';
import { TrainerProfileComponent } from './Components/trainer-profile/trainer-profile.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Gym-Website';
}
