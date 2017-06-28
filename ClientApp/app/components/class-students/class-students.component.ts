import { StudentService } from './../../services/student.service';
import { ClassService } from './../../services/class.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";

@Component({
  selector: 'app-class-students',
  templateUrl: './class-students.component.html',
  styleUrls: ['./class-students.component.css']
})
export class ClassStudentsComponent implements OnInit {
  isChangesSaved: boolean;
  class: any = {};
  classId: number;
  students: any[] = [];
  allStudents: any[] = [];
  selectedItem;
  constructor(private route: ActivatedRoute,
    private classService: ClassService,
    private studentService: StudentService,
    private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.classId = +params['classId'];
      this.classService.getWithChilds(this.classId).subscribe(res => {
        this.class = res;
        this.students = res.students;
      });
      this.loadAllStudents();
    });
  }

  loadAllStudents() {
    this.studentService.getList().subscribe(res => { this.allStudents = res; });
  }

  addStudent(student) {
    this.isChangesSaved = true;
    if (this.students.indexOf(student.id) == -1)
      this.students.push(student.id);
  }
  removeStudent(student) {
    this.isChangesSaved = true;
    this.students.forEach((e, i) => {
      if (e == student.id) {
        this.students.splice(i, 1);
        return;
      }
    });
  }
  saveChanges() {
    this.isChangesSaved = true;
    this.classService.update(this.class.id, this.class).subscribe(res => {
      this.class = res;
      this.students = res.students;
    });
  }
  backToList() {
    this.router.navigate(['/class/new']);
  }
}
