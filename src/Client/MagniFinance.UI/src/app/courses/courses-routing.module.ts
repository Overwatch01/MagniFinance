import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CourseInfoComponent } from "./components/courses/course-info/course-info.component";
import { IndexComponent } from "./components/index.component";


const routes: Routes = [
    { 'path': '', 'component': IndexComponent },
    { 'path': ':id', 'component': CourseInfoComponent }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CoursesRoutingModule { }