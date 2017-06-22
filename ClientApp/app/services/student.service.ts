import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class StudentService {

  constructor(private http: Http) { }

  getList() {
    return this.http.get('api/students')
      .map(res => { return res.json(); });
  }

  add(item: any) {
    return this.http.post('api/students', item).map(res => { return res.json(); });
  }

}
