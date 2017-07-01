import { TranslateService } from '@ngx-translate/core';
import { ExamService } from './../../services/exam.service';
import { SemesterService } from './../../services/semester.service';
import { MaterialService } from './../../services/material.service';
import { ClassService } from './../../services/class.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent extends BaseComponent implements OnInit {
  exams: any[] = [];
  materials: any[] = [];
  classes: any[] = [];
  semesters: any[] = [];
  current: any = {};

  constructor(private examService: ExamService, transate: TranslateService, private classService: ClassService, private materialService: MaterialService, private semesterService: SemesterService) {
    super(transate);
  }

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.semesterService.getList().subscribe(res => { this.semesters = res });
    this.classService.getList().subscribe(res => { this.classes = res });
    this.materialService.getList().subscribe(res => { this.materials = res });
    this.examService.getListIncludeAll().subscribe(res => { this.exams = res });
  }

  addNew(form) {

    // this.current.materialId = this.current.material.id;
    // this.current.semesterId = this.current.semester.id;
    // this.current.classId = this.current.class.id;

    this.examService.add(this.current).subscribe(added => {
      if (added.id > 0) {
        console.log(added)
        this.exams.push(added);
        form.resetForm();
      }
    });
  }

  delete(item) {
    if (confirm(this.delConfirmMessage) == true) {
      this.examService.delete(item).subscribe(id => {
        var index = this.exams.map(i => i.id).indexOf(id);
        this.exams.splice(index, 1);
      });
    }
  }
}