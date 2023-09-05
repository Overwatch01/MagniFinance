export class Student {
    id: number;
    firstName: string;
    lastName: string;
    otherName: string;
    email: string;
}

export class StudentsFilter {
    firstName: string;
    otherName: string;
    lastName: string;
    registrationNumber: string;
}

export interface StudentsStateModel {
    filter: StudentsFilter
}

export const StudentApiPrefix = '/students';