import { outputAst } from '@angular/compiler';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Dispatch } from '@ngxs-labs/dispatch-decorator';
import { StudentsFilter } from '../../models/student';
import { SetStudentFilter } from '../../store';

@Component({
  selector: 'magni-finance-student-filter',
  templateUrl: './student-filter.component.html',
  styleUrls: ['./student-filter.component.scss']
})
export class StudentFilterComponent {

  @Dispatch() setSelectedFilter = (filter: StudentsFilter) => new SetStudentFilter(Object.assign({}, filter))

  @Output() showStudentForm: EventEmitter<boolean> = new EventEmitter<boolean>();

  selectedFilter: StudentsFilter = new StudentsFilter();


  onFilterChange() {
    this.setSelectedFilter(this.selectedFilter)
  }

  clearFilters() {
    this.selectedFilter = new StudentsFilter();
    this.onFilterChange();
  }

  showForm() {
    this.showStudentForm.emit(true)
  }

}
