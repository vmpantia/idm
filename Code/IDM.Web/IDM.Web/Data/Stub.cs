using IDM.Web.Models;
using static IDM.Web.Models.ViewModels.GroupViewModel;

namespace IDM.Web.Data
{
    public class Stub
    {
        public static List<GroupFullInformation> groupList { 
            get
            {
                return new List<GroupFullInformation> {

                    new GroupFullInformation
                    {
                        inputGroup = new Group
                        {
                            InternalID = Guid.NewGuid(),
                            SGAliasName = "sgs-idm-dev",
                            SGDisplayName = "SGS/IDM/DEV",
                            SGClass = "I",
                            Owner_InternalID = Guid.NewGuid(),
                            Admin1_InternalID = Guid.NewGuid(),
                            Admin2_InternalID = Guid.NewGuid(),
                            Admin3_InternalID = Guid.NewGuid(),
                            Status = 0,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null
                        },
                        inputOwner = new Account
                        {
                            InternalID = Guid.NewGuid(),
                            AccountName = "9004070504",
                            FirstName = "Vincent",
                            LastName = "Pantia",
                            Status = 0,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null
                        },
                        inputAdmin1 = new Account
                        {
                            InternalID = Guid.NewGuid(),
                            AccountName = "9004070504",
                            FirstName = "Vincent",
                            LastName = "Pantia",
                            Status = 0,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null
                        },
                        inputAdmin2 = new Account
                        {
                            InternalID = Guid.NewGuid(),
                            AccountName = "9004070504",
                            FirstName = "Vincent",
                            LastName = "Pantia",
                            Status = 0,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null
                        },
                        inputAdmin3 = new Account
                        {
                            InternalID = Guid.NewGuid(),
                            AccountName = "9004070504",
                            FirstName = "Vincent",
                            LastName = "Pantia",
                            Status = 0,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null
                        },
                        inputMailList = new List<Mail>
                        {
                            new Mail
                            {
                                InternalID= Guid.NewGuid(),
                                MailAddress = "sgs-idm-dev@test.com",
                                AliasName = "sgs-idm-dev",
                                MailType = "S1",
                                ReceiveType = "G",
                                PrimaryFlag = 1,
                                Status = 0,
                                CreateDate = DateTime.Now,
                                ModifiedDate = null
                            }
                        }
                    }
                };
            }
        }
    }
}
