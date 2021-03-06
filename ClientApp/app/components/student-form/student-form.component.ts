import { StudentService } from './../../services/student.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {
  public students;
  public student: any = { name: '', middleName: '', lastName :'' };

  constructor(private studentService: StudentService) {
  }

  ngOnInit() {
    this.studentService.getList().subscribe(students => {
      this.students = students;
    });
  }

  addNew() {
    this.studentService.add(this.student).subscribe(res => { this.students.push(res); });
  }

}