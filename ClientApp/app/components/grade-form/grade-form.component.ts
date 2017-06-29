import { TranslateService } from '@ngx-translate/core';
import { GradeService } from './../../services/grade.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-grade-form',
  templateUrl: './grade-form.component.html',
  styleUrls: ['./grade-form.component.css']
})
export class GradeFormComponent extends BaseComponent implements OnInit {

  grade: any = {};
  grades: any[] = [];

  constructor(private gradeService: GradeService, translate: TranslateService) {
    super(translate);
  }

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.gradeService.getList().subscribe((listRes) => { this.grades = listRes; });
  }

  addNew(form) {
    this.gradeService.add(this.grade).subscribe(added => {
      this.grades.push(added);
      form.resetForm();
    });
  }

  delete(studentRegistration) {
    if (confirm(this.delConfirmMessage) == true) {
      this.gradeService.delete(studentRegistration).subscribe(id => {
        var index = this.grades.map(i => i.id).indexOf(id);
        this.grades.splice(index, 1);
      });
    }
  }
}
