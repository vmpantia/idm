import { Injectable } from '@angular/core';
import { Constant } from '../commons/constant.model';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor() { }

  convertStatus(status:number)
  {
      switch (status)
      {
          case Constant.STATUS_INT_ENABLED:
              return Constant.STATUS_STRING_ENABLED;
          case Constant.STATUS_INT_DISABLED:
              return Constant.STATUS_STRING_DISABLED;
          default:
              return Constant.STATUS_STRING_DELETION;
      }
  }
}
