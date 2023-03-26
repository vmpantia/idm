using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class NameValidation : ValidationAttribute
    {
        private IDMDbContext _db;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] splittedValue;
            bool isAdd;

            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;

            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            if (value == null)
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_NULL, validationContext.DisplayName));

            var group = validationContext.ObjectInstance as SecurityGroupDTO;
            if(group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Identify if transaction is Add or Edit
            isAdd = group.InternalID == Guid.Empty;

            switch (validationContext.MemberName?.ToString())
            {
                case Constants.ATTR_SG_ALIASNAME:
                    splittedValue = ((string)value).Split(Constants.DASH);
                    break;
                default: //DisplayName Attribute
                    splittedValue = ((string)value).Split(Constants.SLASH);
                    break;
            }

            //Check alias name or display name format 
            if (group?.Type == Constants.SG_TYPE_INT_INTERNAL && splittedValue.Length <= 2)
                return new ValidationResult(string.Format(Constants.ERROR_SG_NAME_INVALID_FOR_INTERNAL, validationContext.DisplayName));

            if(group?.Type == Constants.SG_TYPE_INT_EXTERNAL && splittedValue.Length <= 3) 
                return new ValidationResult(string.Format(Constants.ERROR_SG_NAME_INVALID_FOR_EXTERNAL, validationContext.DisplayName));

            //If add check if the alias name is already exist
            if (isAdd)
            {
                if (IsNameExist((string)value))
                    return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_DB, validationContext.DisplayName));

                return ValidationResult.Success;
            }

            //If edit get current group info
            var currentGroup = _db.SecurityGroup_MST.Find(group.InternalID);
            if(currentGroup == null)
                return new ValidationResult(Constants.ERROR_SG_NOT_FOUND);

            //Check if alias name or display name has change
            if((validationContext.MemberName?.ToString() == Constants.ATTR_SG_ALIASNAME && 
               currentGroup.AliasName != (string)value && 
               IsNameExist((string)value)) ||
               (validationContext.MemberName?.ToString() == Constants.ATTR_SG_DISPLAYNAME &&
               currentGroup.DisplayName != (string)value &&
               IsNameExist((string)value)))
                return new ValidationResult(string.Format(Constants.ERROR_VALUE_EXIST_DB, validationContext.DisplayName));

            return ValidationResult.Success;
        }

        private bool IsNameExist(string value)
        {
            return _db.SecurityGroup_MST.Where(data => data.AliasName == value ||
                                                       data.DisplayName == value).Any();
        }
    }
}
