using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class MailAddressValidation : ValidationAttribute
    {
        private IDMDbContext _db;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;

            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            if (value == null)
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_NULL, validationContext.DisplayName));

            var group = validationContext.ObjectInstance as SecurityGroupDTO;
            if (group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

             //Check if mail address is already exist in form
             if(IsMailAddressExist(group, value))
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_FORM, validationContext.DisplayName));

            //Check if mail address is already exist in database
            if (IsMailAddressExist((string)value))
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_DB, validationContext.DisplayName));

            return ValidationResult.Success;
        }

        private bool IsMailAddressExist(SecurityGroupDTO input, object value)
        {
            var mailProperties = input.GetType().GetProperties().Where(data => data.Name.Contains("MailAddrress")).ToList();
            return mailProperties.Where(data => data.GetValue(input) == value).Count() > 1;
        }

        private bool IsMailAddressExist(string mailAddress)
        {
            return _db.MailAddress_MST.Where(data => data.MailAddress == mailAddress).Any();
        }
    }
}
