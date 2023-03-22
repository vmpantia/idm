import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constant } from '../commons/constant.model';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  getSGs():Observable<any> {
    return this.http.get<any>(Constant.URL + 'SecurityGroup/GetSGs');
  }
}
