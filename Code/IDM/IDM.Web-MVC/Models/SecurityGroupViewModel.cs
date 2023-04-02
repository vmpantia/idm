using IDM.Business.Models.DTOs;

namespace IDM.Web_MVC.Models
{
    public class SecurityGroupViewModel
    {
        public List<SecurityGroupDTO> sgList { get; set; }
        public SecurityGroupDTO sgInfo { get; set; }
    }
}
