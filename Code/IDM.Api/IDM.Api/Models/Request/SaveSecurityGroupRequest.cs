namespace IDM.Api.Models.Request
{
    public class SaveSecurityGroupRequest : RequestBase
    {
        public SecurityGroupDTO inputSG { get; set; }
    }
}
