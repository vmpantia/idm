using IDM.Business.Models.DTOs;

namespace IDM.Business.Models.Request
{
    public class SaveSecurityGroupRequest : RequestBase
    {
        public SecurityGroupDTO inputSG { get; set; }
    }
}
