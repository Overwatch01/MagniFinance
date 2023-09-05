import { CoursesState } from "src/app/courses/store/course.state";
import { StudentsState } from "src/app/students/store";
import { TeachersState } from "src/app/teachers/store";

export const AppState = [
    StudentsState,
    TeachersState,
    CoursesState
]