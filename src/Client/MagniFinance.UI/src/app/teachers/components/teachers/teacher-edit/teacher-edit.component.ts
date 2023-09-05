import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DataService } from 'src/app/core/services/data.service';
import { Teacher, TeacherApiPrefix } from 'src/app/teachers/models/teacher';

@Component({
  selector: 'magni-finance-teacher-edit',
  templateUrl: './teacher-edit.component.html',
  styleUrls: ['./teacher-edit.component.scss']
})
export class TeacherEditComponent implements OnInit {
  @ViewChild("form", { static: false }) form: NgForm

  @Output() visibleChange: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() recordSaved: EventEmitter<Teacher> = new EventEmitter<Teacher>();
  
  @Input() visible: boolean = false
  @Input() record: any


  model: Teacher
  saving: boolean = false
  addNewTeacher: boolean


  constructor(private http: DataService, private messageService: MessageService) {  }

  ngOnInit(): void {
    if (this.record == null) {
      this.addNewTeacher = true
      this.model = new Teacher()
    } else {
      this.addNewTeacher = false
      this.model = this.record
    }
  }

  onClose() {
    this.visibleChange.emit(this.visible)
    this.form.form.reset();
  }

  close() {
    this.visible = false
  }

  onSubmit() {
    if (this.form.invalid) return;
    var httpRequest = this.http.post(TeacherApiPrefix, this.model);
    this.saving = true;

    if (!this.addNewTeacher)
      httpRequest = this.http.put(TeacherApiPrefix, this.model)

    // this.errors = []
    httpRequest
      .subscribe(() => {
        this.visible = false;
        this.messageService.add({severity: 'success', summary: '', detail: 'Saved successfully' })
        this.recordSaved.emit(this.model)
      }, (err) => {
        this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
      }).add(() => this.saving = false)

  }

}
