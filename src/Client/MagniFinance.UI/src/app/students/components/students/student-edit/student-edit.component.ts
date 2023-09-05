import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DataService } from 'src/app/core/services/data.service';
import { Student, StudentApiPrefix } from 'src/app/students/models/student';

@Component({
  selector: 'magni-finance-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.scss']
})

export class StudentEditComponent implements OnInit {
  @ViewChild("form", { static: false }) form: NgForm

  @Output() visibleChange: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() recordSaved: EventEmitter<Student> = new EventEmitter<Student>();
  
  @Input() visible: boolean = false
  @Input() record: any

  model: Student
  saving: boolean = false
  addNewStudent: boolean

  constructor(private http: DataService, private messageService: MessageService) {  }

  ngOnInit(): void {
    if (this.record == null) {
      this.addNewStudent = true
      this.model = new Student()
    } else {
      this.addNewStudent = false
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
    var httpRequest = this.http.post(StudentApiPrefix, this.model);
    this.saving = true;

    if (!this.addNewStudent)
      httpRequest = this.http.put(StudentApiPrefix, this.model)

    // this.errors = []
    httpRequest
      .subscribe(() => {
        this.visible = false;
        this.messageService.add({severity: 'success', summary: '', detail: 'Student successfully saved. ' })
        this.recordSaved.emit(this.model)
      }, (err) => {
         this.messageService.add({severity: 'error', summary: '', detail: err.error.respMessage })
      }).add(() => this.saving = false)

  }

}
