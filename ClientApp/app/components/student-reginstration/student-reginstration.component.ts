import { TranslateService } from '@ngx-translate/core';
import { StudentRegistrationService } from './../../services/student-registration.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-student-reginstration',
  templateUrl: './student-reginstration.component.html',
  styleUrls: ['./student-reginstration.component.css']
})
export class StudentReginstrationComponent extends BaseComponent implements OnInit {

  studReg: any = {};
  students: any[] = [];
  studentsRegistrations: any[];
  registrationYears: any[] = [];
  grades: any[] = [];

  constructor(private stdRegService: StudentRegistrationService, translate: TranslateService) {
    super(translate);
  }

  ngOnInit() {
    this.loadRegistrationYears();
    this.loadStudents();
    this.loadStudentRegistrations();
    this.loadGrads();
    this.loadTranslations();
  }

  loadStudents() {
    if (this.students.length <= 0) {
      this.students.push({ id: 1, fullName: 'Mahmoud Hboubati', registrationDate: '18/01/2015', registrationYear: { startYear: 2015, endYear: 2016 } });
      this.students.push({ id: 2, fullName: 'Nazeer Hboubati', registrationDate: '18/01/2015', registrationYear: { startYear: 2015, endYear: 2016 } });
      this.students.push({ id: 3, fullName: 'Najwa Hboubati', registrationDate: '18/01/2015', registrationYear: { startYear: 2015, endYear: 2016 } });
    }
  }

  loadRegistrationYears() {
    if (this.registrationYears.length <= 0) {
      this.registrationYears.push({ id: 1, startYear: 2015, endYear: 2016 });
      this.registrationYears.push({ id: 2, startYear: 2016, endYear: 2017 });
      this.registrationYears.push({ id: 3, startYear: 2017, endYear: 2018 });
    }
  }

  loadStudentRegistrations() {
    this.stdRegService.getList().subscribe(listRes => {
      this.studentsRegistrations = listRes;
    });
  }

  loadGrads() {
    if (this.grades.length <= 0) {
      this.grades.push({ id: 1, name: 'grade 1' });
      this.grades.push({ id: 2, name: 'grade 2' });
      this.grades.push({ id: 3, name: 'grade 3' });
    }
  }

  addNew() {
    this.stdRegService.add(this.studReg).subscribe(added => {
      this.studentsRegistrations.push(added);
      this.studReg = {};
    });
  }

  delete(studentRegistration) {
    if (confirm(this.delConfirmMessage) == true) {
      this.stdRegService.delete(studentRegistration).subscribe(id => {
        this.studentsRegistrations.forEach((element, index) => {
          console.log('element.id: ' + element.id)
          console.log('id: ' + id)
          if (index > -1 && element.id == id)
            this.studentsRegistrations.splice(index, index + 1);
        });
      });
    }
  }
}
