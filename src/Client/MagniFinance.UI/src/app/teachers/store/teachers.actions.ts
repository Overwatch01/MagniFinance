import { TeachersFilter } from "../models/teacher";


export class SetTeacherFilter {
    public static readonly type = '[Teachers] SetSelectedFilter';
    constructor(public filter: TeachersFilter) {}
}