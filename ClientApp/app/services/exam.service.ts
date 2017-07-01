import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ExamService extends BaseService {
  constructor(http: Http) {
    super(http, 'api/exam');
  }
}
