import { Injectable } from "@angular/core";
import { Action, State, StateContext } from "@ngxs/store";
import { CourseFilter, CoursesStateModel } from "../models/course";
import { SetCourseFilter } from "./course.actions";

@State<CoursesStateModel>({
    'name': 'courses',
    'defaults': {
        filter: new CourseFilter()
    }
})

@Injectable()
export class CoursesState {

    @Action(SetCourseFilter)
    public SetCourseFilter(ctx: StateContext<CoursesStateModel>, action: SetCourseFilter) {
        ctx.patchState({
            filter: action.filter
        })
    }
}