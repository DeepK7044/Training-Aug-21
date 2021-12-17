import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeExercis4Component } from './practice-exercis4.component';

describe('PracticeExercis4Component', () => {
  let component: PracticeExercis4Component;
  let fixture: ComponentFixture<PracticeExercis4Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticeExercis4Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeExercis4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
