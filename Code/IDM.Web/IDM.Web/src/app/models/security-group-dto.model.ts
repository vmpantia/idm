import { Constant } from "../commons/constant.model";

export class SecurityGroupDTO {
    //SG Details
    public internalID:string = Constant.EMPTY_GUID;
    public aliasName:string = Constant.EMPTY_STRING;
    public displayName:string = Constant.EMPTY_STRING;
    public type:number;
    public typeDescription:string = Constant.EMPTY_STRING;

    //SG Ownership Details
    public ownerInternalID:string = Constant.EMPTY_GUID;;
    public ownerName:string = Constant.EMPTY_STRING;
    public admin1InternalID:string = Constant.EMPTY_GUID;;
    public admin1Name:string = Constant.EMPTY_STRING;
    public admin2InternalID:string = Constant.EMPTY_GUID;;
    public admin2Name:string = Constant.EMPTY_STRING;
    public admin3InternalID:string = Constant.EMPTY_GUID;;
    public admin3Name:string = Constant.EMPTY_STRING;

    //Common Details
    public status:number;
    public statusDescription:string = Constant.EMPTY_STRING;;
    public createdDate:Date = new Date()
    public modifiedDate:Date = new Date()
}
