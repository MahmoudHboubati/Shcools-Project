import { StudyingYearService } from './../../services/studying-year.service';
import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-studying-year',
  templateUrl: './studying-year.component.html',
  styleUrls: ['./studying-year.component.css']
})
export class StudyingYearComponent extends BaseComponent implements OnInit {

  constructor(private studyingService: StudyingYearService, translate: TranslateService) {
    super(translate);
  }

  studyingYears: any[] = [];
  studYear: any = {};

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.studyingService.getList().subscribe((listRes) => { this.studyingYears = listRes; });
  }

  addNew(form) {
    this.studyingService.add(this.studYear).subscribe(added => {
      this.studyingYears.push(added);
      form.resetForm();
    });
  }

  delete(studentRegistration) {
    if (confirm(this.delConfirmMessage) == true) {
      this.studyingService.delete(studentRegistration).subscribe(id => {
        var index = this.studyingYears.map(i => i.id).indexOf(id);
        this.studyingYears.splice(index, 1);
      });
    }
  }
}
