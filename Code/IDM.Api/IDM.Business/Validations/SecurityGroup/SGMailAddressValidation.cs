using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class SGMailAddressValidation : ValidationAttribute
    {
        private IDMDbContext _db;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            MailAddress_MST currentMail;
            bool isAdd;

            //Get IDMDbContext database in service
            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;
            //Check if there's no database found in service
            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            //Check if the value is null
            if (value == null)
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_NULL, validationContext.DisplayName));

            //Get model in validatonContext.ObjectInstance
            var group = validationContext.ObjectInstance as SecurityGroupDTO;
            //Check if there's no model found in validation context
            if (group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Check if mail address is already exist in form
            if (IsMailAddressExist(group, value))
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_FORM, validationContext.DisplayName));

            //Identify if transaction is Add or Edit
            isAdd = group.InternalID == Guid.Empty;

            //Check if the transaction is Add
            if (isAdd)
            {
                //Check if the alias name or display name is exist in the database
                if (IsMailAddressExist((string)value))
                    return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_DB, validationContext.DisplayName));

                return ValidationResult.Success;
            }

            //Edit
            //Get current mail using mail address from value
            var type = Utility.GetMailTypeByAttribute(validationContext.MemberName);

            if(type < 0)
                currentMail = _db.MailAddress_MST.Where(data => data.RelationID == group.InternalID)
                                                 .Where(data => data.PrimaryFlag == Constants.MAIL_FLAG_PRIMARY)
                                                 .First();
            else
                currentMail = _db.MailAddress_MST.Where(data => data.RelationID == group.InternalID)
                                                 .Where(data => data.MailType == type)
                                                 .First();

            if (currentMail == null)
                return new ValidationResult(Constants.ERROR_MAIL_NOT_FOUND);

            //Check if mail address change and check if it's already exist in database    
            if (currentMail.MailAddress != (string)value && 
                IsMailAddressExist((string)value))
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_DB, validationContext.DisplayName));

            return ValidationResult.Success;
        }

        private bool IsMailAddressExist(SecurityGroupDTO input, object value)
        {
            if (value == null || string.IsNullOrEmpty((string)value))
                return false;

            var mailProperties = input.GetType().GetProperties().Where(data => data.Name.Contains(Constants.ATTR_MAILADDRESS) &&
                                                                               data.Name != Constants.ATTR_PRIMARY_MAIL_ADDRESS).ToList();
            return mailProperties.Where(data => data.GetValue(input)?.ToString() == value.ToString()).Count() > 1;
        }

        private bool IsMailAddressExist(string mailAddress)
        {
            return _db.MailAddress_MST.Where(data => data.MailAddress == mailAddress).Any();
        }

    }
}
