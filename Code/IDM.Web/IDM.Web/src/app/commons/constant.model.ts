export class Constant {
    public static URL:string = "https://localhost:7231/"
    public static SLASH:string = "/";
    public static DASH:string = "-";
    public static GUID_EMPTY:string = "00000000-0000-0000-0000-000000000000";
    public static STRING_EMPTY:string = "";
    public static IDM_DOMAIN:string = "@idm.com";
    public static PH_IDM_DOMAIN:string = "@ph.idm.com";

    //Status
    public static STATUS_INT_ENABLED:number = 0;
    public static STATUS_INT_DISABLED:number = 1;
    public static STATUS_INT_DELETION:number = 2;
    public static STATUS_STRING_ENABLED:string = "Enabled";
    public static STATUS_STRING_DISABLED:string = "Disabled";
    public static STATUS_STRING_DELETION:string = "Deletion";
    
    //Type
    public static SG_TYPE_INT_INTERNAL:number = 0;
    public static SG_TYPE_INT_EXTERNAL:number = 1;
    public static SG_TYPE_STRING_INTERNAL:string = "Internal";
    public static SG_TYPE_STRING_EXTERNAL:string = "External";
}
