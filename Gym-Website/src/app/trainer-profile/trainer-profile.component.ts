import { Component, OnInit, Attribute, Input } from '@angular/core';

@Component({
  selector: 'trainer-profile',
  templateUrl: './trainer-profile.component.html',
  styleUrls: ['./trainer-profile.component.css']
})
export class TrainerProfileComponent implements OnInit {
  //name="Farcas Rares"; 
  //description="Antrenor personal,Manager fitness de grup";
  //image_src="rares.jpg";
  @Input() name:string;
  @Input() description:string;
  @Input() image:string;

  constructor(@Attribute('name')name:string, @Attribute('description')description:string, @Attribute('image')image_src:string) { 
    this.name=name;
    this.description=description;
    this.image=image_src;
  }

  ngOnInit(): void {
  }
}
