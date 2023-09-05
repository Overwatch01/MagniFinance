import { CourseFilter } from '../models/course'

export class SetCourseFilter {
    public static readonly type = '[Courses] SetSelectedFilter';
    constructor(public filter: CourseFilter) {}
}