export class Constant {
    public static URL:string = "https://localhost:7231/"
    public static SLASH:string = "/";
    public static DASH:string = "-";
    public static GUID_EMPTY:string = "00000000-0000-0000-0000-000000000000";
    public static STRING_EMPTY:string = "";

    //Status
    public static STATUS_INT_ENABLED:number = 0;
    public static STATUS_INT_DISABLED:number = 1;
    public static STATUS_INT_DELETION:number = 2;
    public static STATUS_STRING_ENABLED:string = "Enabled";
    public static STATUS_STRING_DISABLED:string = "Disabled";
    public static STATUS_STRING_DELETION:string = "Deletion";
    
    //SG Type
    public static SG_TYPE_INT_INTERNAL:number = 0;
    public static SG_TYPE_INT_EXTERNAL:number = 1;
    public static SG_TYPE_STRING_INTERNAL:string = "Internal";
    public static SG_TYPE_STRING_EXTERNAL:string = "External";

    //Mail Owner Type
    public static  MAIL_OWNER_TYPE_GROUP = 0;

    public static MAIL_FLAG_INT_PRIMARY:number = 0;
    public static MAIL_FLAG_INT_SECONDARY:number = 1;
    public static MAIL_FLAG_STRING_PRIMARY:string = "Primary";
    public static MAIL_FLAG_STRING_SECONDARY:string = "Secondary";

    public static MAIL_TYPE_INT_IDM:number = 0;
    public static MAIL_TYPE_INT_REGIONAL:number = 1;
    public static MAIL_TYPE_INT_COMPANY1:number = 2;
    public static MAIL_TYPE_INT_COMPANY2:number = 3;
    public static MAIL_TYPE_STRING_IDM:string = "IDM Mail Address";
    public static MAIL_TYPE_STRING_REGIONAL:string = "Regional Mail Address";
    public static MAIL_TYPE_STRING_COMPANY1:string = "Company Mail Address 1";
    public static MAIL_TYPE_STRING_COMPANY2:string = "Company Mail Address 2";
}
