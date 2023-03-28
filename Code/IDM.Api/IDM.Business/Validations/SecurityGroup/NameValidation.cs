using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class NameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] splittedValue;
            bool isAdd;

            //Check if the value is null
            if (value == null)
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_NULL, validationContext.DisplayName));
            
            //Get model in validatonContext.ObjectInstance
            var group = validationContext.ObjectInstance as SecurityGroupDTO;
            //Check if there's no model found in validation context
            if(group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Check attribute name to be check using validationContext.MemberName
            switch (validationContext.MemberName?.ToString())
            {
                //Case for AliasName attribute
                case Constants.ATTR_SG_ALIASNAME:
                    splittedValue = ((string)value).Split(Constants.DASH);
                    break;
                default: //Case for DisplayName attribute
                    splittedValue = ((string)value).Split(Constants.SLASH);
                    break;
            }

            //Check alias name or display name format 
            if(group.Type == Constants.SG_TYPE_INT_INTERNAL && splittedValue.Length <= 2)
                return new ValidationResult(string.Format(Constants.ERROR_SG_NAME_INVALID_FOR_INTERNAL, validationContext.DisplayName));
            if(group.Type == Constants.SG_TYPE_INT_EXTERNAL && splittedValue.Length <= 3) 
                return new ValidationResult(string.Format(Constants.ERROR_SG_NAME_INVALID_FOR_EXTERNAL, validationContext.DisplayName));
            
            return ValidationResult.Success;
        }
    }
}
