import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Select } from '@ngxs/store';
import { Observable } from 'rxjs';
import { PaginationRequest } from 'src/app/core/models/pagination';
import { DataService } from 'src/app/core/services/data.service';
import { Student, StudentApiPrefix, StudentsFilter } from '../../models/student';
import { StudentSelectors } from '../../store';
import { isEmpty } from 'lodash';
import { toQuery } from 'src/app/shared/classes/utils';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'magni-finance-students',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})

export class StudentComponent implements OnInit {

  @Select(StudentSelectors.getFilter) filter$: Observable<StudentsFilter>

  @Output() showStudentForm: EventEmitter<Student> = new EventEmitter<Student>();

  @Input() reloadData: boolean;
  
  data: Student[]
  filter: StudentsFilter
  loading: boolean
  paginator: PaginationRequest = new PaginationRequest()
  totalRecords: 0

  constructor(private http: DataService, private messageService: MessageService) {}

  ngOnInit(): void {
    this.filter$.subscribe((filter) => {
      this.filter = filter
      if (this.filter && this.paginator)
        this.load(this.paginator)
    })
  }

  ngOnChanges(changes: { [property: string]: SimpleChange}) {
      this.load(this.paginator)
  }

  load(event: any) {
    this.loading = true
    let requestUrl = `${StudentApiPrefix}?${PaginationRequest.toQuery(event)}`
    if(!isEmpty(this.filter)) requestUrl += `&${toQuery(this.filter)}`
    this.http.get(requestUrl).subscribe((resp: any) => {
      this.data = resp.data.data
      this.totalRecords = resp.data.totalCount
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    }).add(() => this.loading = false)
  }

  onEditStudent(student: Student) {
    this.http.get(`${StudentApiPrefix}/${student.id}`).subscribe((res: any) => {
      this.messageService.add({severity: 'success', summary: '', detail: 'Student record successfully. ' })
      this.showStudentForm.emit(res.data)
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    })
  }

  onDeleteStudent(student: any) {
    this.http.delete(`${StudentApiPrefix}/${student.id}`).subscribe((res) => {
      this.messageService.add({severity: 'success', summary: '', detail: 'Student record deleted successfully. ' })
      this.load(this.paginator)
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    })
  }

}
