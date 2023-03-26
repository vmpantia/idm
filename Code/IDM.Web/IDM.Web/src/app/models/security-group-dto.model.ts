import { Constant } from "../commons/constant.model";

export class SecurityGroupDTO {
    //SG Details
    public internalID:string = Constant.GUID_EMPTY;
    public aliasName:string = Constant.STRING_EMPTY;
    public displayName:string = Constant.STRING_EMPTY;
    public type:number;
    public typeDescription:string = Constant.STRING_EMPTY;

    //SG Ownership Details
    public ownerInternalID:string = Constant.GUID_EMPTY;;
    public ownerName:string = Constant.STRING_EMPTY;
    public admin1InternalID:string = Constant.GUID_EMPTY;;
    public admin1Name:string = Constant.STRING_EMPTY;
    public admin2InternalID:string = Constant.GUID_EMPTY;;
    public admin2Name:string = Constant.STRING_EMPTY;
    public admin3InternalID:string = Constant.GUID_EMPTY;;
    public admin3Name:string = Constant.STRING_EMPTY;

    //Common Details
    public status:number;
    public statusDescription:string = Constant.STRING_EMPTY;;
    public createdDate:Date = new Date()
    public modifiedDate:Date = new Date()
}
