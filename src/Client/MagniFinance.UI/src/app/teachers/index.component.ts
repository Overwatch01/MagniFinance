import { Component } from '@angular/core';
import { Teacher } from './models/teacher';

@Component({
  selector: 'magni-finance-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {

  editDialogVisibility: boolean = false
  reloadData: boolean = false
  teacherRecord: Teacher | null;

  onShowTeacherForm(event: any) {
    this.editDialogVisibility = true;
    this.teacherRecord = event;
  }

}
