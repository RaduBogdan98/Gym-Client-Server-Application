import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/Services/messenger.service';

@Component({
  selector: 'app-slide-show',
  templateUrl: './slide-show.component.html',
  styleUrls: ['./slide-show.component.css']
})
export class SlideShowComponent implements OnInit {
  isUserLogged = false;

  constructor(private messengerService : MessengerService) { }

  ngOnInit(): void {
    this.messengerService.getLoginState().subscribe((state)=>{
      if(state == 'hidden'){
        this.isUserLogged = true;
      }
    })
  }

  displayLoginPage(){
    this.messengerService.sendLoginState('visible');
  }

  logOut(){
    this.messengerService.sendUser(null);
    this.isUserLogged = false;
  }
}
