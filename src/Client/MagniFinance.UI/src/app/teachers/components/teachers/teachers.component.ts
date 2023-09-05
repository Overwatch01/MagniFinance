import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Select } from '@ngxs/store';
import { isEmpty } from 'lodash';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { PaginationRequest } from 'src/app/core/models/pagination';
import { DataService } from 'src/app/core/services/data.service';
import { toQuery } from 'src/app/shared/classes/utils';
import { Teacher, TeacherApiPrefix, TeachersFilter } from '../../models/teacher';
import { TeacherSelectors } from '../../store';

@Component({
  selector: 'magni-finance-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss']
})
export class TeachersComponent implements OnInit {

  @Output() showTeacherForm: EventEmitter<Teacher> = new EventEmitter<Teacher>();

  @Input() reloadData: boolean;
  
  @Select(TeacherSelectors.getFilter) filter$: Observable<TeachersFilter>


  data: Teacher[]
  filter: TeachersFilter
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
    let requestUrl = `${TeacherApiPrefix}?${PaginationRequest.toQuery(event)}`
    if(!isEmpty(this.filter)) requestUrl += `&${toQuery(this.filter)}`
    this.http.get(requestUrl).subscribe((resp: any) => {
      this.data = resp.data.data
      this.totalRecords = resp.data.totalCount
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    }).add(() => this.loading = false)
  }

  onEditTeacher(student: Teacher) {
    this.http.get(`${TeacherApiPrefix}/${student.id}`).subscribe((res: any) => {
      this.messageService.add({severity: 'success', summary: '', detail: 'Teacher record successfully. ' })
      this.showTeacherForm.emit(res.data)
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    })
  }

  onDeleteTeacher(student: any) {
    this.http.delete(`${TeacherApiPrefix}/${student.id}`).subscribe((res) => {
      this.messageService.add({severity: 'success', summary: '', detail: 'Teacher record deleted successfully. ' })
      this.load(this.paginator)
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    })
  }

}
