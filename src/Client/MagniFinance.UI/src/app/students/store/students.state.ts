import { Injectable } from "@angular/core";
import { Action, State, StateContext } from "@ngxs/store";
import { StudentsFilter, StudentsStateModel } from "../models/student";
import { SetStudentFilter } from "./students.actions";

@State<StudentsStateModel>({
    'name': 'students',
    'defaults': {
        filter: new StudentsFilter()
    }
})

@Injectable()
export class StudentsState {

    @Action(SetStudentFilter)
    public SetStudentFilter(ctx: StateContext<StudentsStateModel>, action: SetStudentFilter) {
        ctx.patchState({
            filter: action.filter
        })
    }
}