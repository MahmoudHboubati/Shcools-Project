import { StudentClassService } from './student-class.service';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { BaseService } from './base.service';

@Injectable()
export class StudentService extends BaseService {
  constructor(http: Http, private studentClassService: StudentClassService) {
    super(http, 'api/students');
  }

  getListByClass(classObject) {
    return this.http.get(this.baseUrl + '/class/' + classObject.id).map(res => { return res.json(); });
  }
  // getListByClass(classObject) {
  //   return this.studentClassService.getStudentsByClassId(classObject.id);
  // }

}
