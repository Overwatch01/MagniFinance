import { Selector } from "@ngxs/store";
import { CoursesStateModel } from "../models/course";
import { CoursesState } from "./course.state";

export class CourseSelectors {
    @Selector([CoursesState])
    public static getFilter(state: CoursesStateModel) {
        return state.filter
    }
}