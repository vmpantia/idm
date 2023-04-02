using IDM.Business.Models.DTOs;
using IDM.Business.Validations.SecurityGroup;

namespace IDM.Business.Models.Request
{
    public class SaveSecurityGroupRequest : RequestBase
    {
        public SecurityGroupDTO inputSG { get; set; }
    }
}
