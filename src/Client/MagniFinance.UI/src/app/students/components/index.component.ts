import { Component } from '@angular/core';
import { Student } from '../models/student';

@Component({
  selector: 'magni-finance-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {

  editDialogVisibility: boolean = false
  reloadData: boolean = false
  studentRecord: Student | null;

  onShowStudentForm(event: any) {
    this.editDialogVisibility = true;
    this.studentRecord = event;
  }

}
