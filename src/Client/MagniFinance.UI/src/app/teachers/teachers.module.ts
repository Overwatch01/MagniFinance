import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeachersRoutingModule } from './teachers-routing.module';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index.component';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherFilterComponent } from './components/teacher-filter/teacher-filter.component';
import { TeacherEditComponent } from './components/teachers/teacher-edit/teacher-edit.component';


@NgModule({
  declarations: [
    IndexComponent,
    TeachersComponent,
    TeacherFilterComponent,
    TeacherEditComponent
  ],
  imports: [
    CommonModule,
    TeachersRoutingModule,
    SharedModule
  ]
})
export class TeachersModule { }
