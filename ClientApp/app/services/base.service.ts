import { Http } from '@angular/http';

export class BaseService {

  protected baseUrl: string = '';
  protected http: Http;

  constructor(http: Http, baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  getList() {
    return this.http.get(this.baseUrl).map(res => { return res.json(); });
  }

  add(item: any) {
    return this.http.post(this.baseUrl, item).map(res => { return res.json(); });
  }

  delete(item: any) {
    return this.http.delete(this.baseUrl + '/' + item.id).map(res => { return res.json(); });
  }
}