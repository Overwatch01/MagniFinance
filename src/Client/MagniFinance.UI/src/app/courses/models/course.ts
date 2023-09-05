export class Course {
    id: number;
    name: string;
    code: string;
}

export class CourseFilter {
    name: string;
    code: string;
}

export interface CoursesStateModel {
    filter: CourseFilter
}

export const CourseApiPrefix = '/courses';