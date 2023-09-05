import { Selector } from "@ngxs/store";
import { TeachersStateModel } from "../models/teacher";
import { TeachersState } from "./teachers.state";

export class TeacherSelectors {
    @Selector([TeachersState])
    public static getFilter(state: TeachersStateModel) {
        return state.filter
    }
}