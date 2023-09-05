import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppMainComponent } from './core/components/app.main.component';
import { AppNotFoundComponent } from './core/errors/app.not-found.component';


@NgModule({
  imports: [RouterModule.forRoot([
    { path: '', component: AppMainComponent,
      children: [
        { 'path': '', 'loadChildren': () => import('../app/dashboard/dashboard.module').then(m => m.DashboardModule) },
        { 'path': 'students', 'loadChildren': () => import('../app/students/students.module').then(m => m.StudentsModule) },
        { 'path': 'teachers', 'loadChildren': () => import('../app/teachers/teachers.module').then(m => m.TeachersModule) },
        { 'path': 'courses', 'loadChildren': () => import('../app/courses/courses.module').then(m => m.CoursesModule) }
      ]
    },
    { path: 'notfound', component: AppNotFoundComponent },
    { path: '**', redirectTo: '/notfound' },
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
