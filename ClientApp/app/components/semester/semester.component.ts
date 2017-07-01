import { StudyingYearService } from './../../services/studying-year.service';
import { TranslateService } from '@ngx-translate/core';
import { SemesterService } from './../../services/semester.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-semester',
  templateUrl: './semester.component.html',
  styleUrls: ['./semester.component.css']
})
export class SemesterComponent extends BaseComponent implements OnInit {
  studyingYears: any[] = [];
  current: {} = {};
  semesters: any[] = [];

  constructor(private semesterService: SemesterService, translate: TranslateService, private studyingYearService: StudyingYearService) {
    super(translate);
  }

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.semesterService.getList().subscribe((listRes) => { this.semesters = listRes; });
    this.studyingYearService.getList().subscribe((listRes) => { this.studyingYears = listRes; });
  }

  addNew(form) {
    this.semesterService.add(this.current).subscribe(added => {
      this.semesters.push(added);
      form.resetForm();
    });
  }

  delete(item) {
    if (confirm(this.delConfirmMessage) == true) {
      this.semesterService.delete(item).subscribe(id => {
        var index = this.semesters.map(i => i.id).indexOf(id);
        this.semesters.splice(index, 1);
      });
    }
  }
}
