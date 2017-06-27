import { Http } from '@angular/http';
import { LookupsService } from './lookups.service';
import { Injectable } from '@angular/core';

@Injectable()
export class GradeService extends LookupsService {

  constructor(http: Http) {
    super(http, '/api/grade');
  }

}
