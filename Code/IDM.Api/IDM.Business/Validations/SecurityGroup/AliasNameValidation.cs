﻿using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class AliasNameValidation : ValidationAttribute
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

            if (isAdd && IsAliasNameExist(group.AliasName))
                    return new ValidationResult(Constants.ERROR_SG_ALIASNAME_EXIST);

            var currentGroup = _db.SecurityGroup_MST.Find(group.InternalID);
            if(currentGroup != null)
            {
                //Check if AliasName has change
                if(currentGroup.AliasName != group.AliasName && 
                    IsAliasNameExist(group.AliasName))
                    return new ValidationResult(Constants.ERROR_SG_ALIASNAME_EXIST);
            }

            return ValidationResult.Success;
        }

        private bool IsAliasNameExist(string aliasName)
        {
            return _db.SecurityGroup_MST.Where(data => data.AliasName == aliasName).Any();
        }
    }
}
