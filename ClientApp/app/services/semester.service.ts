import { Http } from '@angular/http';
import { LookupsService } from './lookups.service';
import { Injectable } from '@angular/core';

@Injectable()
export class SemesterService extends LookupsService {

  constructor(http: Http) {
    super(http, 'api/semester');
  }

  // getListIncludeAll() {
  //   return this.http.get(this.baseUrl + '/getListIncludeAll').map(res => { return res.json(); });
  // }

}
