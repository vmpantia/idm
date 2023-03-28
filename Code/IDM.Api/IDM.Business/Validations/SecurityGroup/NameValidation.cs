using IDM.Business.Models.DTOs;
using IDM.Common;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class NameValidation : ValidationAttribute
    {
        private readonly RequiredAttribute _requiredAttribute;
        private readonly MaxLengthAttribute _maxLengthAttribute;
        private readonly bool _isRequired;
        public NameValidation(bool isRequired = false, int maxLength = 255)
        {
            _isRequired = isRequired;

            _requiredAttribute = new RequiredAttribute();
            _maxLengthAttribute = new MaxLengthAttribute(maxLength);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] splittedValue;

            //Check if the value is not null or empty
            if (_isRequired && !_requiredAttribute.IsValid(value))
                return _requiredAttribute.GetValidationResult(value, validationContext);

            //Check if the value is not exceed on the max length
            if (!_maxLengthAttribute.IsValid(value))
                return _maxLengthAttribute.GetValidationResult(value, validationContext);

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
