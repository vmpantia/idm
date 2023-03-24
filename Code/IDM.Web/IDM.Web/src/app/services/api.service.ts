import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constant } from '../commons/constant.model';
import { SecurityGroupDTO } from '../models/security-group-dto.model';
import { SaveSecurityGroupRequest } from '../models/requests/save-security-group-request.model';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  getSGs():Observable<SecurityGroupDTO[]> {
    return this.http.get<SecurityGroupDTO[]>(Constant.URL + 'SecurityGroup/GetSGs');
  }
  
  saveSG(model:SaveSecurityGroupRequest) {
    return this.http.post(Constant.URL + 'SecurityGroup/SaveSG', model);
  }
}
