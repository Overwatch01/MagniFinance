import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherFilterComponent } from './teacher-filter.component';

describe('TeacherFilterComponent', () => {
  let component: TeacherFilterComponent;
  let fixture: ComponentFixture<TeacherFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TeacherFilterComponent]
    });
    fixture = TestBed.createComponent(TeacherFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
