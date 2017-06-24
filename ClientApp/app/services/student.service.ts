import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { BaseService } from './base.service';

@Injectable()
export class StudentService extends BaseService {
  constructor(http: Http) {
    super(http, 'api/students');
  }
}
