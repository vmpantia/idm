﻿using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess.Entities;

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
                default: //Deletion
                    return Constants.STATUS_STRING_DELETION;
            }
        }

        public static string ConvertSGType(int type)
        {
            switch (type)
            {
                case Constants.SG_TYPE_INT_INTERNAL:
                    return Constants.SG_TYPE_STRING_INTERNAL;
                default: //External
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

        public static int ConvertMailType(string attribute)
        {
            switch (attribute)
            {
                case Constants.PROPERTY_IDM_EMAIL_ADDRESS:
                    return Constants.MAIL_TYPE_INT_IDM;
                case Constants.PROPERTY_REG_EMAIL_ADDRESS:
                    return Constants.MAIL_TYPE_INT_REGIONAL;
                case Constants.PROPERTY_COMP1_EMAIL_ADDRESS:
                    return Constants.MAIL_TYPE_INT_COMPANY1;
                default: //Company Email Address 2
                    return Constants.MAIL_TYPE_INT_COMPANY2;
            }
        }

        public static string ConvertPrimaryFlag(int primary)
        {
            switch (primary)
            {
                case Constants.MAIL_FLAG_INT_PRIMARY:
                    return Constants.MAIL_FLAG_STRING_PRIMARY;
                default: //Secondary
                    return Constants.MAIL_FLAG_STRING_SECONDARY;
            }
        }

        public static string SelectEmailAddress(List<EmailAddress_MST> emailAddressList, int emailType = -1)
        {
            List<EmailAddress_MST> result;
            if (emailType == -1)
                result = emailAddressList.Where(data => data.PrimaryFlag == Constants.MAIL_FLAG_INT_PRIMARY).ToList();
            else
                result = emailAddressList.Where(data => data.EmailType == emailType).ToList();

            return result == null || result.Count == 0 ? string.Empty : result.First().EmailAddress;
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

        public static SecurityGroupDTO ParseSecurityGroup(SecurityGroup_MST data, List<EmailAddress_MST> emailAddressList)
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
                PrimaryEmailAddress = SelectEmailAddress(emailAddressList),
                IDMEmailAddress = SelectEmailAddress(emailAddressList, Constants.MAIL_TYPE_INT_IDM),
                RegionalEmailAddress = SelectEmailAddress(emailAddressList, Constants.MAIL_TYPE_INT_REGIONAL),
                CompanyEmailAddress1 = SelectEmailAddress(emailAddressList, Constants.MAIL_TYPE_INT_COMPANY1),
                CompanyEmailAddress2 = SelectEmailAddress(emailAddressList, Constants.MAIL_TYPE_INT_COMPANY2),
                Status = data.Status,
                StatusDescription = ConvertStatus(data.Status),
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        public static List<EmailAddress_MST> ParseEmailAddressList(SecurityGroupDTO data)
        {
            var result = new List<EmailAddress_MST>();
            var emailAddressList = data.GetType().GetProperties().Where(data => data.Name.Contains(Constants.PROPERTY_EMAIL_ADDRESS) &&
                                                                     data.Name != Constants.PROPERTY_PRIMARY_EMAIL_ADDRESS).ToList();
            emailAddressList.ForEach(email =>
            {
                var emailAddress = email.GetValue(data)?.ToString();
                if (string.IsNullOrEmpty(emailAddress))
                    return;

                var primaryFlag = data.PrimaryEmailAddress == emailAddress ? Constants.MAIL_FLAG_INT_PRIMARY : Constants.MAIL_FLAG_INT_SECONDARY;
                result.Add(ParseEmailAddress(emailAddress, 
                                             data.InternalID,
                                             Constants.MAIL_OWNER_TYPE_GROUP, 
                                             ConvertMailType(email.Name),
                                             primaryFlag));
            });

            return result;
        }

        public static EmailAddress_MST ParseEmailAddress(string emailAddress, Guid relationID, int ownerType, int mailType, int primaryFlag)
        {
            return new EmailAddress_MST
            {
                EmailAddress = emailAddress,
                RelationID = relationID,
                OwnerType = ownerType,
                EmailType = mailType,
                PrimaryFlag = primaryFlag,
                Status = Constants.STATUS_INT_ENABLED,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };
        }
    }
}
