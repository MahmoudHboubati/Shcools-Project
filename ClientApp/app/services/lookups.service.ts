import { BaseService } from './base.service';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class LookupsService extends BaseService {

  constructor(http: Http, baseUrl: string) {
    super(http, baseUrl);
   }
}
