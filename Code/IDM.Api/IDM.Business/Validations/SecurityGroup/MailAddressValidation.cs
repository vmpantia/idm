using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IDM.Business.Validations.SecurityGroup
{
    public class MailAddressValidation : ValidationAttribute
    {
        private readonly RequiredAttribute _requiredAttribute;
        private readonly MaxLengthAttribute _maxLengthAttribute;
        private readonly EmailAddressAttribute _emailAttribute;
        private readonly bool _isRequired;
        public MailAddressValidation(bool isRequired = false, int maxLength = 255)
        {
            _isRequired = isRequired;

            _requiredAttribute = new RequiredAttribute();
            _maxLengthAttribute= new MaxLengthAttribute(maxLength);
            _emailAttribute = new EmailAddressAttribute();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Check if the value is not null or empty
            if (_isRequired && !_requiredAttribute.IsValid(value))
                return _requiredAttribute.GetValidationResult(value, validationContext);

            //Check if the value is not exceed on the max length
            if (!_maxLengthAttribute.IsValid(value))
                return _maxLengthAttribute.GetValidationResult(value, validationContext);

            //Check if the value is a valid email address
            if(!string.IsNullOrEmpty(value?.ToString()) && !_emailAttribute.IsValid(value))
                return new ValidationResult(string.Format(Constants.ERROR_MAILS_NOT_VALID, value));

            return ValidationResult.Success;
        }
    }
}
