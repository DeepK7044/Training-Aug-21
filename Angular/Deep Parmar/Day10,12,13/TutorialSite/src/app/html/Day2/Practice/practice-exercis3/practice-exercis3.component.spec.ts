import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeExercis3Component } from './practice-exercis3.component';

describe('PracticeExercis3Component', () => {
  let component: PracticeExercis3Component;
  let fixture: ComponentFixture<PracticeExercis3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticeExercis3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeExercis3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
