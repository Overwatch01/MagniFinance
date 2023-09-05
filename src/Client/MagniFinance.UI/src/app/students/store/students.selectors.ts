import { Selector } from "@ngxs/store";
import { StudentsStateModel } from "../models/student";
import { StudentsState } from "./students.state";

export class StudentSelectors {
    @Selector([StudentsState])
    public static getFilter(state: StudentsStateModel) {
        return state.filter
    }
}