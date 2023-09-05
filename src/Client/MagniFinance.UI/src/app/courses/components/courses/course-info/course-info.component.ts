import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/core/services/data.service';
import { CourseApiPrefix } from 'src/app/courses/models/course';

@Component({
  selector: 'magni-finance-course-info',
  templateUrl: './course-info.component.html',
  styleUrls: ['./course-info.component.scss']
})
export class CourseInfoComponent implements OnInit {

  private routeSub: Subscription
  courseSubjects: []
  courseStudents: []
  courseName: string
  courseCode: string
  teacherName: string;
  teacherEmail: string;
  teacherAnnualSalary: string;
 

  constructor(private route: ActivatedRoute, private http: DataService, private messageService: MessageService) {
    
  }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.getCourseInfo(params['id'])
    });
  }

  getCourseInfo(id: number) {
    this.getCourseSubject(id)
    this.getCourseStudents(id)
    this.getCourseTeacher(id)
  }

  private getCourseSubject(id: number) : void {
    this.http.get(`${CourseApiPrefix}/${id}/subjects`).subscribe((res: any) => {
      this.courseName = res.data.name
      this.courseCode = res.data.courseCode
      this.courseSubjects = res.data.subjects
    })
  }

  private getCourseStudents(id: number) : void {
    this.http.get(`${CourseApiPrefix}/${id}/students`).subscribe((res: any) => {
      console.log(res)
      this.courseStudents = res.data
    })
  }

  private getCourseTeacher(id: number) : void {
    this.http.get(`${CourseApiPrefix}/${id}/teacher`).subscribe((res: any) => {
      this.teacherName = res.data.firstName + ' ' + res.data.lastName
      this.teacherEmail = res.data.email
      this.teacherAnnualSalary = res.data.annualSalary
    })
  }

  formatCurrency(value: any) {
    return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
  }

}
