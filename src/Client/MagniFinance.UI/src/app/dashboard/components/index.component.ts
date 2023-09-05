import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/services/data.service';
import { CourseApiPrefix } from 'src/app/courses/models/course';
import { StudentApiPrefix } from 'src/app/students/models/student';
import { TeacherApiPrefix } from 'src/app/teachers/models/teacher';

@Component({
  selector: 'magni-finance-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  totalCourse: number = 0;
  totalCourseEnabled: number = 0;
  totalCourseDisabled: number = 0;

  totalStudent: number = 0;
  totalStudentEnabled: number = 0;
  totalStudentDisabled: number = 0;

  totalTeacher: number = 0;
  totalTeacherEnabled: number = 0;
  totalTeacherDisabled: number = 0;
  

  constructor(private http: DataService) {}

  ngOnInit(): void {
   this.getCourseSummary();
   this.getTeacherSummary();
   this.getStudentSummary();
  }

  private getCourseSummary() : void {
    this.http.get(`${CourseApiPrefix}/summary`).subscribe((res: any) => {
      this.totalCourse = res.data.totalCourse
      this.totalCourseEnabled = res.data.totalEnabled
      this.totalCourseDisabled = res.data.totalDisabled
    })
  }

  private getTeacherSummary() : void {
    this.http.get(`${TeacherApiPrefix}/summary`).subscribe((res: any) => {
      this.totalTeacher = res.data.totalTeachers
      this.totalTeacherEnabled = res.data.totalTeacherEnabled
      this.totalTeacherDisabled = res.data.totalTeacherDisabled
    })
  }

  private getStudentSummary() : void {
    this.http.get(`${StudentApiPrefix}/summary`).subscribe((res: any) => {
      this.totalStudent = res.data.totalStudent
      this.totalStudentEnabled = res.data.totalStudentEnabled
      this.totalStudentDisabled = res.data.totalStudentDisabled
    })
  }



}
