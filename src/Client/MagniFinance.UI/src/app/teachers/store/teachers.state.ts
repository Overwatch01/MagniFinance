import { Injectable } from "@angular/core";
import { Action, State, StateContext } from "@ngxs/store";
import { TeachersFilter, TeachersStateModel } from "../models/teacher";
import { SetTeacherFilter } from "./teachers.actions";

@State<TeachersStateModel>({
    'name': 'teachers',
    'defaults': {
        filter: new TeachersFilter()
    }
})

@Injectable()
export class TeachersState {

    @Action(SetTeacherFilter)
    public SetTeacherFilter(ctx: StateContext<TeachersStateModel>, action: SetTeacherFilter) {
        ctx.patchState({
            filter: action.filter
        })
    }
}