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
            if(_db == null)
                return new ValidationResult(Constants.ERROR_NO_DATABASE_FOUND);

            bool isAdd;
            var group = validationContext.ObjectInstance as SecurityGroupDTO;

            if (group == null)
                return ValidationResult.Success;

            isAdd = group.InternalID == Guid.Empty;

            if (isAdd && IsDisplayNameExist(group.DisplayName))
                    return new ValidationResult(Constants.ERROR_SG_DISPLAYNAME_EXIST);

            var currentGroup = _db.SecurityGroup_MST.Find(group.InternalID);
            if(currentGroup != null)
            {
                //Check if DisplayName has change
                if (currentGroup.DisplayName != group.DisplayName &&
                    IsDisplayNameExist(group.DisplayName))
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
