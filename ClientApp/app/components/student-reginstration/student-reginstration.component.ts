import { StudentRegistrationService } from './../../services/student-registration.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-reginstration',
  templateUrl: './student-reginstration.component.html',
  styleUrls: ['./student-reginstration.component.css']
})
export class StudentReginstrationComponent implements OnInit {

  studReg: any = {};
  students: any[] = [];
  studentsRegistrations: any[];
  registrationYears: any[] = [];

  constructor(private stdRegService: StudentRegistrationService) { }

  ngOnInit() {
    this.loadRegistrationYears();
    this.loadStudents();
    this.loadStudentRegistrations();
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
}
