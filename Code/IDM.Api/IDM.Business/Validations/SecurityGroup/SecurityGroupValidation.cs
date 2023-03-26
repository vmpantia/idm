using IDM.Business.Models.DTOs;
using IDM.Business.Models.Request;
using IDM.Common;
using IDM.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Validations.SecurityGroup
{
    public class SecurityGroupValidation : ValidationAttribute
    {
        private IDMDbContext _db;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            bool isAdd;

            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;
            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            var request = validationContext.ObjectInstance as SaveSecurityGroupRequest;
            if (request == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Identify if transaction is Add or Edit
            isAdd = request.inputSG.InternalID == Guid.Empty;

            if (isAdd)
                return ValidationResult.Success;

            //If edit get current group info
            var currentGroup = _db.SecurityGroup_MST.Find(request.inputSG.InternalID);
            if (currentGroup == null)
                return new ValidationResult(Constants.ERROR_SG_NOT_FOUND);

            if (Utility.IsDataPrestine<SecurityGroupDTO>(request.inputSG, Utility.ParseSecurityGroup(currentGroup)))
                return new ValidationResult(Constants.ERROR_SG_NO_CHANGES);

            return ValidationResult.Success;
        }
    }
}
