using IDM.Business.DTO;

namespace IDM.Web.Models
{
    public class GroupViewModel
    {
        public AccountDTO userAccount { get; set; }
        public List<GroupDTO> groupList { get; set; }
        public GroupDTO groupInfo { get; set; }
    }
}
