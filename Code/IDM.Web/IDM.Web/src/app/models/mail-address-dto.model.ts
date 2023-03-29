import { Constant } from "../commons/constant.model";

export class MailAddressDTO {
    //SG Details
    public mailAddress:string = Constant.STRING_EMPTY;
    public relationID:string = Constant.GUID_EMPTY;
    public ownerType:number = 0;
    public mailType:number = 0;
    public mailTypeDescription:string = Constant.STRING_EMPTY;
    public primaryFlag:number = 0;
    public primaryFlagDescription:string = Constant.STRING_EMPTY;

    //Common Details
    public status:number = 0;
    public statusDescription:string = Constant.STRING_EMPTY;;
    public createdDate:Date = new Date()
    public modifiedDate:Date = new Date()
}
