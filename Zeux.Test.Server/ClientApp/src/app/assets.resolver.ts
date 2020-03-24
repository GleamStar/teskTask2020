import { Injectable } from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Resolve} from '@angular/router';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Asset} from './my-assets/my-assets.component';

@Injectable()
export class AssetsResolver implements Resolve<Array<Asset>> {
  constructor(private http: HttpClient) {

  }

  resolve(route: ActivatedRouteSnapshot) {
    const  httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const type = route.paramMap.get('type');
    const uriAsset = '/api/asset/Get/' + type;
    return this.http.get<Array<Asset>>(uriAsset, httpOptions);
  }
}
