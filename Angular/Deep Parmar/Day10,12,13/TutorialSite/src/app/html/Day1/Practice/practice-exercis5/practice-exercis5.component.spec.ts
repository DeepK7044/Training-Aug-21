import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeExercis5Component } from './practice-exercis5.component';

describe('PracticeExercis5Component', () => {
  let component: PracticeExercis5Component;
  let fixture: ComponentFixture<PracticeExercis5Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticeExercis5Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeExercis5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
