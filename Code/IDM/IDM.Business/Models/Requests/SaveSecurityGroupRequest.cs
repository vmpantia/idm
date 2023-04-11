using IDM.Business.Models.DTOs;
using IDM.Business.Validations.SecurityGroup;

namespace IDM.Business.Models.Requests
{
    public class SaveSecurityGroupRequest : RequestBase
    {
        public SecurityGroupDTO inputSG { get; set; }
    }
}
