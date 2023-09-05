import { Component, EventEmitter, Output } from '@angular/core';
import { Dispatch } from '@ngxs-labs/dispatch-decorator';
import { TeachersFilter } from '../../models/teacher';
import { SetTeacherFilter } from '../../store';

@Component({
  selector: 'magni-finance-teacher-filter',
  templateUrl: './teacher-filter.component.html',
  styleUrls: ['./teacher-filter.component.scss']
})
export class TeacherFilterComponent {

  @Dispatch() setSelectedFilter = (filter: TeachersFilter) => new SetTeacherFilter(Object.assign({}, filter))

  @Output() showTeacherForm: EventEmitter<boolean> = new EventEmitter<boolean>();

  selectedFilter: TeachersFilter = new TeachersFilter();

  onFilterChange() {
    this.setSelectedFilter(this.selectedFilter)
  }

  clearFilters() {
    this.selectedFilter = new TeachersFilter();
    this.onFilterChange();
  }

  showForm() {
    this.showTeacherForm.emit(true)
  }
}


