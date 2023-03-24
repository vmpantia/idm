using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess.Entities;

namespace IDM.Business
{
    public class Utility
    {
        public static string ConvertStatus(int status)
        {
            switch (status)
            {
                case Constants.STATUS_INT_ENABLED:
                    return Constants.STATUS_STRING_ENABLED;
                case Constants.STATUS_INT_DISABLED:
                    return Constants.STATUS_STRING_DISABLED;
                default:
                    return Constants.STATUS_STRING_DELETION;
            }
        }

        public static string ConvertType(int type)
        {
            switch (type)
            {
                case Constants.SG_TYPE_INT_INTERNAL:
                    return Constants.SG_TYPE_STRING_INTERNAL;
                default:
                    return Constants.SG_TYPE_STRING_EXTERNAL;
            }
        }

        public static SecurityGroupDTO ParseSecurityGroup(SecurityGroup_MST data)
        {
            return new SecurityGroupDTO
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName,
                DisplayName = data.DisplayName,
                Type = data.Type,
                TypeDescription = ConvertType(data.Type),
                OwnerInternalID = data.OwnerInternalID,
                OwnerName = Constants.NA,
                Admin1InternalID = data.Admin1InternalID,
                Admin1Name = Constants.NA,
                Admin2InternalID = data.Admin2InternalID,
                Admin2Name = Constants.NA,
                Admin3InternalID = data.Admin3InternalID,
                Admin3Name = Constants.NA,
                Status = data.Status,
                StatusDescription = ConvertStatus(data.Status),
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        public static SecurityGroup_MST ParseSecurityGroup(SecurityGroupDTO data)
        {
            return new SecurityGroup_MST
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName,
                DisplayName = data.DisplayName,
                Type = data.Type,
                OwnerInternalID = data.OwnerInternalID,
                Admin1InternalID = data.Admin1InternalID,
                Admin2InternalID = data.Admin2InternalID,
                Admin3InternalID = data.Admin3InternalID,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }
    }
}
