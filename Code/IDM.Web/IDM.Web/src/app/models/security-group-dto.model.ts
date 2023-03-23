export class SecurityGroupDTO {
    //SG Details
    public internalID:string;
    public aliasName:string;
    public displayName:string;
    public type:number;
    public typeDescription:string;

    //SG Ownership Details
    public ownerInternalID:string;
    public ownerName:string;
    public admin1InternalID:string;
    public admin1Name:string;
    public admin2InternalID:string;
    public admin2Name:string;
    public admin3InternalID:string;
    public admin3Name:string;

    //Common Details
    public status:number;
    public statusDescription:string;
    public createdDate:Date = new Date()
    public modifiedDate:Date = new Date()
}
