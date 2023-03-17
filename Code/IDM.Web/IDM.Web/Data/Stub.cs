using IDM.Business.DTO;

namespace IDM.Web.Data
{
    public class Stub
    {
        public static List<GroupDTO> groupList { 
            get
            {
                return new List<GroupDTO> {

                    new GroupDTO
                    {
                        InternalID = Guid.NewGuid(),
                        SGAliasName = "sgs-idm-dev",
                        SGDisplayName = "SGS/IDM/DEV",
                        SGClass = "I",
                        OwnerInternalID = Guid.NewGuid(),
                        OwnerName = "Vincent Pantia",
                        Admin1InternalID = Guid.NewGuid(),
                        Admin1Name = "Vincent Pantia",
                        Admin2InternalID = Guid.NewGuid(),
                        Admin2Name = "Vincent Pantia",
                        Admin3InternalID = Guid.NewGuid(),
                        Admin3Name = "Vincent Pantia",
                        MailAddressList = new List<string>
                        {
                            "sgs-idm-dev@sony.com"
                        },
                        Status = 0,
                        CreateDate = DateTime.Now,
                        ModifiedDate = null,
                    }
                };
            }
        }
    }
}
