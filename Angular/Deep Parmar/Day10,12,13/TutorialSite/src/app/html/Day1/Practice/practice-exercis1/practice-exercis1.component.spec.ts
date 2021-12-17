import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeExercis1Component } from './practice-exercis1.component';

describe('PracticeExercis1Component', () => {
  let component: PracticeExercis1Component;
  let fixture: ComponentFixture<PracticeExercis1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticeExercis1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeExercis1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
