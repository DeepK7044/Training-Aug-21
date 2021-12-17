import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeExercis2Component } from './practice-exercis2.component';

describe('PracticeExercis2Component', () => {
  let component: PracticeExercis2Component;
  let fixture: ComponentFixture<PracticeExercis2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticeExercis2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeExercis2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
