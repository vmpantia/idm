using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess.Entities;
using System.ComponentModel;

namespace IDM.Business
{
    public class Utility
    {
        public static bool IsDataPrestine<T>(T newData, T oldData, out List<string> propertiesChanged)
        {
            propertiesChanged = new List<string>();

            var properties = newData.GetType().GetProperties();
            foreach(var property in properties)
            {
                var newValue = property.GetValue(newData)?.ToString();
                var oldValue = property.GetValue(oldData)?.ToString();

                if (newValue != oldValue)
                    propertiesChanged.Add(property.Name);
            }
            return propertiesChanged.Count == 0;
        }

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

        public static string ConvertSGType(int type)
        {
            switch (type)
            {
                case Constants.SG_TYPE_INT_INTERNAL:
                    return Constants.SG_TYPE_STRING_INTERNAL;
                default:
                    return Constants.SG_TYPE_STRING_EXTERNAL;
            }
        }

        public static string CovertMailType(int type)
        {
            switch (type)
            {
                case Constants.MAIL_TYPE_INT_IDM:
                    return Constants.MAIL_TYPE_STRING_IDM;
                case Constants.MAIL_TYPE_INT_REGIONAL:
                    return Constants.MAIL_TYPE_STRING_REGIONAL;
                case Constants.MAIL_TYPE_INT_COMPANY1:
                    return Constants.MAIL_TYPE_STRING_COMPANY1;
                default: //Company Mail 2
                    return Constants.MAIL_TYPE_STRING_COMPANY2;
            }
        }

        public static SecurityGroup_MST ParseSecurityGroup(SecurityGroupDTO data)
        {
            return new SecurityGroup_MST
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName.Trim(),
                DisplayName = data.DisplayName.Trim(),
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

        public static SecurityGroupDTO ParseSecurityGroup(SecurityGroup_MST data, List<MailAddress_MST> mailAddresses)
        {
            return new SecurityGroupDTO
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName,
                DisplayName = data.DisplayName,
                Type = data.Type,
                TypeDescription = ConvertSGType(data.Type),
                OwnerInternalID = data.OwnerInternalID,
                OwnerName = Constants.NA,
                Admin1InternalID = data.Admin1InternalID,
                Admin1Name = Constants.NA,
                Admin2InternalID = data.Admin2InternalID,
                Admin2Name = Constants.NA,
                Admin3InternalID = data.Admin3InternalID,
                Admin3Name = Constants.NA,
                MailAddresses = ParseMailAddress(mailAddresses),
                Status = data.Status,
                StatusDescription = ConvertStatus(data.Status),
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        public static List<MailAddress_MST> ParseMailAddress(List<MailAddressDTO> mailAddresses, Guid relationID)
        {
            var result = new List<MailAddress_MST>();
            mailAddresses.ForEach(mail =>
            {
                result.Add(new MailAddress_MST
                {
                    MailAddress = mail.MailAddress.Trim(),
                    RelationID = relationID,
                    OwnerType = mail.OwnerType,
                    MailType = mail.MailType,
                    PrimaryFlag = mail.PrimaryFlag,
                    Status = mail.Status,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                });
            });
            return result;
        }

        public static List<MailAddressDTO> ParseMailAddress(List<MailAddress_MST> mailAddresses)
        {
            var result = new List<MailAddressDTO>();
            mailAddresses.ForEach(mail =>
            {
                result.Add(new MailAddressDTO
                {
                    MailAddress = mail.MailAddress,
                    RelationID = mail.RelationID,
                    OwnerType = mail.OwnerType,
                    MailType = mail.MailType,
                    MailDescription = CovertMailType(mail.MailType),
                    PrimaryFlag = mail.PrimaryFlag,
                    Status = mail.Status,
                    CreatedDate = mail.CreatedDate,
                    ModifiedDate = mail.ModifiedDate
                });
            });
            return result;
        }
    }
}
