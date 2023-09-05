import { Component, EventEmitter, Output } from '@angular/core';
import { Dispatch } from '@ngxs-labs/dispatch-decorator';
import { CourseFilter } from '../../models/course';
import { SetCourseFilter } from '../../store/course.actions';

@Component({
  selector: 'magni-finance-course-filter',
  templateUrl: './course-filter.component.html',
  styleUrls: ['./course-filter.component.scss']
})
export class CourseFilterComponent {
  @Dispatch() setSelectedFilter = (filter: CourseFilter) => new SetCourseFilter(Object.assign({}, filter))

  @Output() showCourseForm: EventEmitter<boolean> = new EventEmitter<boolean>();

  selectedFilter: CourseFilter = new CourseFilter();



  onFilterChange() {
    this.setSelectedFilter(this.selectedFilter)
  }

  clearFilters() {
    this.selectedFilter = new CourseFilter();
    this.onFilterChange();
  }

  showForm() {
    this.showCourseForm.emit(true)
  }

}
