import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ClassService extends BaseService {

  constructor(http: Http) {
    super(http, 'api/class');
  }

}
