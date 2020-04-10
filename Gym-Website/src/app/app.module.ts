import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon' 
import {MatSidenavModule} from '@angular/material/sidenav'; 
import {MatCardModule} from '@angular/material/card'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import { TrainerProfileComponent } from './trainer-profile/trainer-profile.component';
import { TrainerService } from './trainer.service';
import { TrainersSectionComponent } from './trainers-section/trainers-section.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    TrainerProfileComponent,
    TrainersSectionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatCardModule
  ],
  providers: [
    TrainerService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
