import { NgModule } from '@angular/core';
import { StudentsRoutingModule } from './students-routing.module';
import { SharedModule } from '../shared/shared.module';
import { StudentEditComponent } from './components/students/student-edit/student-edit.component';
import { StudentFilterComponent } from './components/student-filter/student-filter.component';
import { IndexComponent } from './components/index.component';
import { StudentComponent } from './components/students/student.component';



@NgModule({
  declarations: [
    IndexComponent,
    StudentComponent,
    StudentEditComponent,
    StudentFilterComponent
  ],
  imports: [
    SharedModule,
    StudentsRoutingModule
  ]
})
export class StudentsModule { }
