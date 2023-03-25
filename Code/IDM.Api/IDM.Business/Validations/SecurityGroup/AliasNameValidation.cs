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
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            bool isAdd;
            var group = validationContext.ObjectInstance as SecurityGroupDTO;

            if (group == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Identify if transaction is Add or Edit
            isAdd = group.InternalID == Guid.Empty;

            //If add check if the alias name is already exist
            if (isAdd && IsAliasNameExist(group.AliasName))
                    return new ValidationResult(Constants.ERROR_SG_ALIASNAME_EXIST);

            //If edit get current group info
            var currentGroup = _db.SecurityGroup_MST.Find(group.InternalID);
            if(currentGroup == null)
                return new ValidationResult(Constants.ERROR_SG_NOT_EXIST);

            //Check if alias name has change
            if(currentGroup.AliasName != group.AliasName &&
                IsAliasNameExist(group.AliasName))
            {
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
