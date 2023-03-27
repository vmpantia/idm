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

            //Get IDMDbContext database in service
            _db = validationContext.GetService(typeof(IDMDbContext)) as IDMDbContext;
            //Check if there's no database found in service
            if (_db == null)
                return new ValidationResult(Constants.ERROR_DATABASE_NOT_FOUND);

            //Get model in validatonContext.ObjectInstance
            var request = validationContext.ObjectInstance as SaveSecurityGroupRequest;
            //Check if there's no model found in validation context
            if (request == null)
                return new ValidationResult(Constants.ERROR_MODEL_NOT_FOUND);

            //Identify if transaction is Add or Edit
            isAdd = request.inputSG.InternalID == Guid.Empty;

            if (isAdd)
                return ValidationResult.Success;

            //Edit
            //Get current group using InternalID from form
            var currentGroup = _db.SecurityGroup_MST.Find(request.inputSG.InternalID);
            //Check if current group is not found
            if (currentGroup == null)
                return new ValidationResult(Constants.ERROR_SG_NOT_FOUND);

            //Check if the data is prestine
            //if (Utility.IsDataPrestine<SecurityGroupDTO>(request.inputSG, Utility.ParseSecurityGroup(currentGroup)))
            //    return new ValidationResult(Constants.ERROR_SG_NO_CHANGES);

            return ValidationResult.Success;
        }
    }
}
