export class Teacher {
    id: number;
    firstName: string;
    lastName: string;
    otherName: string;
    email: string;
}

export class TeachersFilter {
    firstName: string;
    otherName: string;
    lastName: string;
}

export interface TeachersStateModel {
    filter: TeachersFilter
}

export const TeacherApiPrefix = '/teachers';