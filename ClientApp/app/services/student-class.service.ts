import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class StudentClassService extends BaseService {

  constructor(http: Http) {
    super(http, 'api/StudentClass');
  }

  getStudentsByClassId(id){
    return this.http.get('api/studentClass/class/' + id).map(res => { return res.json(); });
  }

}
