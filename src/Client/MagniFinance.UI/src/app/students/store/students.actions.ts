import { StudentsFilter } from '../models/student'

export class SetStudentFilter {
    public static readonly type = '[Students] SetSelectedFilter';
    constructor(public filter: StudentsFilter) {}
}