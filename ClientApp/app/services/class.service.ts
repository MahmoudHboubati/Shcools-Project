import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ClassService extends BaseService {

  constructor(http: Http) {
    super(http, 'api/class');
  }

  getWithChilds(id) {
    return this.http.get(this.baseUrl + '/withChilds/' + id).map(res => { return res.json(); });
  }

  update(id, item) {
    return this.http.put(this.baseUrl + '/' + id, item).map(res => { return res.json(); });
  }

}
