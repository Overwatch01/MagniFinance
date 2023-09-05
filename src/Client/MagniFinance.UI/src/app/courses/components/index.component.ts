import { Component } from '@angular/core';
import { Course } from '../models/course';

@Component({
  selector: 'magni-finance-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {

  editDialogVisibility: boolean = false
  reloadData: boolean = false
  courseRecord: Course | null;

  onShowCourseForm(event: any) {
    this.editDialogVisibility = true;
    this.courseRecord = event;
  }

}
