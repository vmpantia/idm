using System.Net.Mail;

namespace IDM.Web.Models.ViewModels
{
    public class GroupViewModel
    {
        public Account userAccount { get; set; }
        public List<GroupFullInformation> groupList { get; set; }
        public GroupFullInformation groupInfo { get; set; }

        public class GroupFullInformation
        {
            public Group inputGroup { get; set; }
            public Account inputOwner { get; set; }
            public Account inputAdmin1 { get; set; }
            public Account inputAdmin2 { get; set; }
            public Account inputAdmin3 { get; set; }
            public List<Mail> inputMailList { get; set; }
        }
    }
}
