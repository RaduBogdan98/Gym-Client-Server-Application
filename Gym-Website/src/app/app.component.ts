import { Component, Input, OnInit } from '@angular/core';
import { MessengerService } from './Services/messenger.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  showLogin=false;

  constructor(private messengerService:MessengerService){}
  ngOnInit(): void {
    this.messengerService.getLoginState().subscribe(state => {
      if(state == 'visible'){
        this.showLogin=true;
      }
      else if (state == 'hidden'){
        this.showLogin=false;
      }
    })
  }
}
