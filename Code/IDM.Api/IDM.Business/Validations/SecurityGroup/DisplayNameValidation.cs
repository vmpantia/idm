using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace IDM.Business.Validations.SecurityGroup
{
    public class DisplayNameValidation : ValidationAttribute
    {
        private IDMDbContext _db;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;
            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            bool isAdd;
            var group = validationContext.ObjectInstance as SecurityGroupDTO;

            if (group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Identify if transaction is Add or Edit
            isAdd = group.InternalID == Guid.Empty;

            //Check display name format 
            var splittedDisplayName = group.DisplayName.Split(Constants.SLASH);
            if (group.Type == Constants.SG_TYPE_INT_INTERNAL && splittedDisplayName.Length <= 2)
                return new ValidationResult(Constants.ERROR_SG_INVALID_DISPLAYNAME_FOR_INTERNAL);

            if (group.Type == Constants.SG_TYPE_INT_EXTERNAL && splittedDisplayName.Length <= 3)
                return new ValidationResult(Constants.ERROR_SG_INVALID_DISPLAYNAME_FOR_EXTERNAL);

            //If add check if the display name is already exist
            if (isAdd) 
            { 
                if(IsDisplayNameExist(group.DisplayName))
                    return new ValidationResult(Constants.ERROR_SG_DISPLAYNAME_EXIST);

                return ValidationResult.Success;
            }

            //If edit get current group info
            var currentGroup = _db.SecurityGroup_MST.Find(group.InternalID);
            if (currentGroup == null)
                return new ValidationResult(Constants.ERROR_SG_NOT_EXIST);

            //Check if display name has change
            if (currentGroup.DisplayName != group.DisplayName &&
                IsDisplayNameExist(group.DisplayName))
            {
                return new ValidationResult(Constants.ERROR_SG_DISPLAYNAME_EXIST);
            }

            return ValidationResult.Success;
        }

        private bool IsDisplayNameExist(string displayName)
        {
            return _db.SecurityGroup_MST.Where(data => data.DisplayName == displayName).Any();
        }
    }
}
