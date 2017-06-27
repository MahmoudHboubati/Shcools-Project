import { StudyingYearService } from './../../services/studying-year.service';
import { GradeService } from './../../services/grade.service';
import { ClassService } from './../../services/class.service';
import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent extends BaseComponent implements OnInit {

  classObj = {};
  classes: any[] = [];
  grades: any[] = [];
  stdYears: any[] = [];

  constructor(translate: TranslateService, private classService: ClassService, private gradesService: GradeService, private stdYearService: StudyingYearService) {
    super(translate);
  }

  ngOnInit() {
    this.loadAll();
    this.loadLookups();
  }

  loadAll() {
    this.classService.getList().subscribe(res => { this.classes = res; });
  }


  addNew(form) {
    this.classService.add(this.classObj).subscribe(added => {
      this.classes.push(added);
      form.resetForm();
    });
  }

  loadLookups() {
    this.gradesService.getList().subscribe(res=>{this.grades = res;});
    this.stdYearService.getList().subscribe(res=>{this.stdYears = res;});
  }

  delete(deleteItem) {
    if (confirm(this.delConfirmMessage) == true) {
      this.classService.delete(deleteItem).subscribe(id => {
        this.classes.forEach((element, index) => {
          if (index > -1 && element.id == id)
            this.classes.splice(index, index + 1);
        });
      });
    }
  }
}
