import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Router } from '@angular/router';
import { Select } from '@ngxs/store';
import { isEmpty } from 'lodash';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { PaginationRequest } from 'src/app/core/models/pagination';
import { DataService } from 'src/app/core/services/data.service';
import { toQuery } from 'src/app/shared/classes/utils';
import { Course, CourseApiPrefix, CourseFilter } from '../../models/course';
import { CourseSelectors } from '../../store/course.selectors';

@Component({
  selector: 'magni-finance-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  @Select(CourseSelectors.getFilter) filter$: Observable<CourseFilter>

  @Output() showStudentForm: EventEmitter<Course> = new EventEmitter<Course>();

  @Input() reloadData: boolean;
  
  data: Course[]
  filter: CourseFilter
  loading: boolean
  paginator: PaginationRequest = new PaginationRequest()
  totalRecords: 0

  constructor(private http: DataService, private messageService: MessageService, private router: Router) {}

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
    let requestUrl = `${CourseApiPrefix}?${PaginationRequest.toQuery(event)}`
    if(!isEmpty(this.filter)) requestUrl += `&${toQuery(this.filter)}`
    this.http.get(requestUrl).subscribe((resp: any) => {
      this.data = resp.data.data
      this.totalRecords = resp.data.totalCount
    }, (err) => {
      this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
    }).add(() => this.loading = false)
  }

  viewCourseDetail(course: any) {
    this.router.navigate(['courses', course.id])
  }

  getCourseDuration(duration: number): string {
    if (duration > 1) 
        return `${duration} Years`
    else 
      return `${duration} Year`
  }

}
