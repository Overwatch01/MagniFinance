import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppMainComponent } from './core/components/app.main.component';
import { AppNotFoundComponent } from './core/errors/app.not-found.component';


@NgModule({
  imports: [RouterModule.forRoot([
    { path: '', component: AppMainComponent, 
      children: [
        { 'path': 'students', 'loadChildren': () => import('../app/students/students.module').then(m => m.StudentsModule) }
      ]
    },
    { path: 'notfound', component: AppNotFoundComponent },
    { path: '**', redirectTo: '/notfound' },
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
