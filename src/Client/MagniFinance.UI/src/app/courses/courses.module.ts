import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './components/index.component';
import { CoursesRoutingModule } from './courses-routing.module';
import { CoursesComponent } from './components/courses/courses.component';
import { CourseFilterComponent } from './components/course-filter/course-filter.component';
import { SharedModule } from '../shared/shared.module';
import { CourseInfoComponent } from './components/courses/course-info/course-info.component';



@NgModule({
  declarations: [
    IndexComponent,
    CoursesComponent,
    CourseFilterComponent,
    CourseInfoComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    CoursesRoutingModule
  ]
})
export class CoursesModule { }
