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

  convertType(type:number)
  {
      switch (type)
      {
          case Constant.SG_TYPE_INT_INTERNAL:
              return Constant.SG_TYPE_STRING_INTERNAL;
          default:
              return Constant.SG_TYPE_STRING_EXTERNAL;
      }
  }

  convertMailType(type:number)
  {
    switch (type)
    {
        case Constant.MAIL_TYPE_INT_IDM:
            return Constant.MAIL_TYPE_STRING_IDM;
        case Constant.MAIL_TYPE_INT_REGIONAL:
            return Constant.MAIL_TYPE_STRING_REGIONAL;
        case Constant.MAIL_TYPE_INT_COMPANY1:
            return Constant.MAIL_TYPE_STRING_COMPANY1;
        default: //Company Mail 2
            return Constant.MAIL_TYPE_STRING_COMPANY2;
    }
  }   
  
  convertPrimaryFlag(primary:number) 
  {
    switch (primary)
    {
        case Constant.MAIL_FLAG_INT_PRIMARY:
            return Constant.MAIL_FLAG_STRING_PRIMARY;
        default: //Secondary
            return Constant.MAIL_FLAG_STRING_SECONDARY;
    }
  }
}
