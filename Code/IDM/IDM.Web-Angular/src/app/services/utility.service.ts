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

  delay(milliseconds : number) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
  } 

  covertSGType(type:number){
    switch(type){
      case Constant.SG_TYPE_INT_INTERNAL:
        return Constant.SG_TYPE_STRING_INTERNAL;
      default:
        return Constant.SG_TYPE_STRING_EXTERNAL;
    }
  }
}
