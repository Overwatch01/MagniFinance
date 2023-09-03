import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'magni-finance-students',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})

export class IndexComponent implements OnInit {

  ngOnInit(): void {
    console.log("Student component launched")
  }

}
