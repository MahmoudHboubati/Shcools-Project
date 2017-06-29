import { StudentClassService } from './../../services/student-class.service';
import { StudentService } from './../../services/student.service';
import { ClassService } from './../../services/class.service';
import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-student-class',
  templateUrl: './student-class.component.html',
  styleUrls: ['./student-class.component.css']
})
export class StudentClassComponent extends BaseComponent implements OnInit {
  selectedClass: any;
  allStudents: any[] = [];
  students: any[] = [];
  classes: any[] = [];
  studentsClasses: any[] = [];

  constructor(translateService: TranslateService, private classService: ClassService, private studentService: StudentService, private studentClassService: StudentClassService) {
    super(translateService);
  }

  ngOnInit() {
    this.loadTranslations();
    this.loadAllStudents();
    this.loadClasses();
  }

  loadStudents(classObject: any) {
    // this.studentService.getListByClass(classObject).subscribe(res => { this.students = res; });
    this.selectedClass = classObject;
    this.studentService.getListByClass(classObject).subscribe(res => {
      this.students = res;
      this.identifyExisting();
    });
  }

  loadStudentClassesByClass(classObject: any) {
    this.studentClassService.getStudentsByClassId(classObject.id).subscribe(res => { console.log(res); });
  }

  loadClasses() {
    this.classService.getList().subscribe(res => { this.classes = res; });
  }

  loadAllStudents() {
    this.studentService.getList().subscribe(res => { this.allStudents = res; });
  }

  addStudent(student) {
    this.studentClassService.add({ classId: this.selectedClass.id, studentId: student.id }).subscribe(res => {
      this.students.push(student);
      this.identifyExisting();
    });
  }

  private identifyExisting() {
    this.allStudents.forEach((student, index) => {
      student.isExist = this.students.some((s => s.id === student.id));
      this.allStudents[index] = student;
    });
  }

  delete(item) {
    if (confirm(this.delConfirmMessage) == true) {


      this.studentClassService.delete(item).subscribe(id => {
        this.students.forEach((element, index) => {
          var index = this.students.map(i => i.id).indexOf(id);
          this.students.splice(index, 1);
        });
        this.identifyExisting();
      });
    }
  }
}