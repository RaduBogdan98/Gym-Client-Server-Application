import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainersSectionComponent } from './trainers-section.component';

describe('TrainersSectionComponent', () => {
  let component: TrainersSectionComponent;
  let fixture: ComponentFixture<TrainersSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainersSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainersSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
