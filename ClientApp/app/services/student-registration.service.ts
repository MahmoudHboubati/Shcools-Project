import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class StudentRegistrationService extends BaseService {

  constructor(http: Http) {
    super(http, 'api/studentRegistration');
  }

}
