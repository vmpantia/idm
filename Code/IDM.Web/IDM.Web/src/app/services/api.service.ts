import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constant } from '../commons/constant.model';
import { SecurityGroupDTO } from '../models/security-group-dto.model';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  getSGs():Observable<SecurityGroupDTO[]> {
    return this.http.get<SecurityGroupDTO[]>(Constant.URL + 'SecurityGroup/GetSGs');
  }
}
