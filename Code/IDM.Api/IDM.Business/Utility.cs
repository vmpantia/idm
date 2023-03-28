using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess.Entities;
using System.ComponentModel;

namespace IDM.Business
{
    public class Utility
    {
        public static bool IsDataPrestine<T>(T newData, T oldData)
        {
            bool result;

            var properties = newData.GetType().GetProperties();
            foreach(var property in properties)
            {
                var newValue = property.GetValue(newData);
                var oldValue = property.GetValue(oldData);

                if (newValue != oldValue)
                    return false;
            }
            return true;
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

        public static int GetMailTypeByAttribute(string attribute)
        {
            switch (attribute)
            {
                case Constants.ATTR_IDM_MAIL_ADDRESS:
                    return Constants.MAIL_TYPE_IDM;
                case Constants.ATTR_REG_MAIL_ADDRESS:
                    return Constants.MAIL_TYPE_REGIONAL;
                case Constants.ATTR_COMP1_MAIL_ADDRESS:
                    return Constants.MAIL_TYPE_COMPANY1;
                case Constants.ATTR_COMP2_MAIL_ADDRESS:
                    return Constants.MAIL_TYPE_COMPANY2;
                default:
                    return -1;
            }
        }

        private static string SelectMailAddress(List<MailAddress_MST> mailaddesses, int mailType = -1)
        {
            List<MailAddress_MST> result;

            if (mailaddesses == null || mailaddesses.Count == 0)
                return string.Empty;

            if(mailType < 0)
                result = mailaddesses.Where(data => data.PrimaryFlag == Constants.MAIL_FLAG_PRIMARY).ToList();
            else
                result = mailaddesses.Where(data => data.MailType == mailType).ToList();

            if (result.Any())
                return result.First().MailAddress ?? string.Empty;

            return string.Empty;
        }

        public static SecurityGroupDTO ParseSecurityGroup(SecurityGroup_MST group, List<MailAddress_MST> mailaddesses)
        {
            return new SecurityGroupDTO
            {
                InternalID = group.InternalID,
                AliasName = group.AliasName,
                DisplayName = group.DisplayName,
                Type = group.Type,
                TypeDescription = ConvertType(group.Type),
                OwnerInternalID = group.OwnerInternalID,
                OwnerName = Constants.NA,
                Admin1InternalID = group.Admin1InternalID,
                Admin1Name = Constants.NA,
                Admin2InternalID = group.Admin2InternalID,
                Admin2Name = Constants.NA,
                Admin3InternalID = group.Admin3InternalID,
                Admin3Name = Constants.NA,
                PrimaryMailAddress = SelectMailAddress(mailaddesses),
                IDMMailAddress = SelectMailAddress(mailaddesses, Constants.MAIL_TYPE_IDM),
                RegionalMailAddress = SelectMailAddress(mailaddesses, Constants.MAIL_TYPE_REGIONAL),
                CompanyMailAddress1 = SelectMailAddress(mailaddesses, Constants.MAIL_TYPE_COMPANY1),
                CompanyMailAddress2 = SelectMailAddress(mailaddesses, Constants.MAIL_TYPE_COMPANY2),
                Status = group.Status,
                StatusDescription = ConvertStatus(group.Status),
                CreatedDate = group.CreatedDate,
                ModifiedDate = group.ModifiedDate
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

        public static List<MailAddress_MST> ParseMailAddresses(SecurityGroupDTO input)
        {
            var result = new List<MailAddress_MST>();

            var getMailProperties = input.GetType().GetProperties().Where(data => data.Name.Contains(Constants.ATTR_MAILADDRESS))
                                                                   .Where(data => data.Name != Constants.ATTR_PRIMARY_MAIL_ADDRESS)
                                                                   .ToList();
            getMailProperties.ForEach(property =>
            {
                var mail = property.GetValue(input)?.ToString();
                if (string.IsNullOrEmpty(mail))
                    return;

                var mailType = GetMailTypeByAttribute(property.Name);
                result.Add(ParseMailAddress(input.InternalID, mail, mailType, Constants.MAIL_OWNER_TYPE_GROUP));
            });

            return result;
        }

        public static MailAddress_MST ParseMailAddress(Guid sgInternalID, string mailAddress, int mailType, int ownerType)
        {
            return new MailAddress_MST
            {
                MailAddress = mailAddress,
                RelationID = sgInternalID,
                OwnerType = ownerType,
                MailType = mailType,
                PrimaryFlag = Constants.MAIL_FLAG_SECONDARY,
                Status = Constants.STATUS_INT_ENABLED,
                CreatedDate = DateTime.Now,
                ModifiedDate = null                
            };
        }
    }
}
