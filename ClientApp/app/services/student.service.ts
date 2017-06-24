import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

export class BaseService {

  protected baseUrl: string = '';
  protected http: Http;

  constructor(http: Http, baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  getList() {
    return this.http.get(this.baseUrl)
      .map(res => { return res.json(); });
  }

  add(item: any) {
    return this.http.post(this.baseUrl, item)
      .map(res => { return res.json(); });
  }
}

@Injectable()
export class StudentService extends BaseService {

  constructor(http: Http) {
    super(http, 'api/students');
  }

}
