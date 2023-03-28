using IDM.Business;
using IDM.Business.Contractors;
using IDM.Business.Models.DTOs;
using IDM.Business.Models.Request;
using IDM.Common;
using IDM.Domain.Exceptions;
using IDM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace IDM.Domain.Services
{
    public class SecurityGroupService : ISecurityGroupService
    {
        private readonly IDMDbContext _db;
        private readonly IMailService _mail;
        public SecurityGroupService(IDMDbContext db, IMailService mail)
        {
            _db = db;
            _mail = mail;
        }

        public async Task<IEnumerable<SecurityGroupDTO>> GetSGsAsync()
        {
            var result = new List<SecurityGroupDTO>();
            var groups = await _db.SecurityGroup_MST.Where(data => data.Status != Constants.STATUS_INT_DELETION)
                                                    .ToListAsync();
            groups.ForEach(group =>
            {
                var mailAddresses = _mail.GetMailAddressByRelationID(_db, group.InternalID);
                result.Add(Utility.ParseSecurityGroup(group, mailAddresses.ToList()));
            });
            return result;
        }

        public async Task<IEnumerable<SecurityGroupDTO>> GetSGsByStatusAsync(int status)
        {
            var result = new List<SecurityGroupDTO>();
            var groups = await _db.SecurityGroup_MST.Where(data => data.Status == status)
                                                    .ToListAsync();
            groups.ForEach(group =>
            {
                var mailAddresses = _mail.GetMailAddressByRelationID(_db, group.InternalID);
                result.Add(Utility.ParseSecurityGroup(group, mailAddresses.ToList()));
            });
            return result;
        }

        public async Task<SecurityGroupDTO> GetSGByIDAsync(Guid internalID)
        {
            var group = await _db.SecurityGroup_MST.FindAsync(internalID);
            if (group == null)
                throw new ServiceException(string.Format(Constants.ERROR_VALUE_NOT_FOUND_DB, "Security Group"));

            var mailAddresses = _mail.GetMailAddressByRelationID(_db, group.InternalID);

            return Utility.ParseSecurityGroup(group, mailAddresses.ToList());
        }

        public async Task SaveSGAsync(SaveSecurityGroupRequest request)
        {
            if (request == null)
                throw new ServiceException(Constants.ERROR_SG_SAVE_REQUEST_NULL);

            var result = await ValidateSecurityGroup(request.inputSG);
            if (!string.IsNullOrEmpty(result))
                throw new ServiceException(result);

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    switch (request.FunctionID)
                    {
                        case Constants.FUNCTION_ID_ADD_INTERNAL_SG_BY_USER:
                        case Constants.FUNCTION_ID_ADD_EXTERNAL_SG_BY_USER:
                            await InsertSecurityGroup_MST(request.inputSG);
                            await _mail.InsertMailAdresss_MST(_db, request.inputSG);
                            break;
                        case Constants.FUNCTION_ID_EDIT_INTERNAL_SG_BY_USER:
                        case Constants.FUNCTION_ID_EDIT_EXTERNAL_SG_BY_USER:
                            await UpdateSecurityGroup_MST(request.inputSG);
                            await _mail.DeleteMailAddress_MST(_db, request.inputSG.InternalID);
                            await _mail.InsertMailAdresss_MST(_db, request.inputSG);
                            break;
                    }
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private async Task InsertSecurityGroup_MST(SecurityGroupDTO input)
        {
            input.InternalID = Guid.NewGuid();
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = null;

            await _db.AddAsync(Utility.ParseSecurityGroup(input));
            var result = await _db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_SG_INSERT);
        }

        private async Task UpdateSecurityGroup_MST(SecurityGroupDTO input)
        {
            var data = await _db.SecurityGroup_MST.FindAsync(input.InternalID);
            if (data == null)
                throw new ServiceException(string.Format(Constants.ERROR_VALUE_NOT_FOUND_DB, "Security Group"));

            //data.InternalID = input.InternalID;
            //data.AliasName = input.AliasName;
            data.DisplayName = input.DisplayName;
            data.Type = input.Type;
            data.OwnerInternalID = input.OwnerInternalID;
            data.Admin1InternalID = input.Admin1InternalID;
            data.Admin2InternalID = input.Admin2InternalID;
            data.Admin3InternalID = input.Admin3InternalID;
            data.Status = input.Status;
            //data.CreatedDate = input.CreatedDate;
            data.ModifiedDate = DateTime.Now;

            var result = await _db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_SG_UPDATE);
        }


        public async Task<string> ValidateSecurityGroup(SecurityGroupDTO input)
        {
            var isAdd = input.InternalID == Guid.Empty;
            var propertiesChanged = new List<string>();

            if (!isAdd)
            {
                var currentGroup = await _db.SecurityGroup_MST.FindAsync(input.InternalID);
                if (currentGroup == null)
                    return string.Format(Constants.ERROR_VALUE_NOT_FOUND_DB, "Security Group");

                var currentMailAddresses = _mail.GetMailAddressByRelationID(_db, input.InternalID);

                if (Utility.IsDataPrestine<SecurityGroupDTO>(input, 
                                                             Utility.ParseSecurityGroup(currentGroup, currentMailAddresses.ToList()), 
                                                             out propertiesChanged))
                    return string.Format(Constants.ERROR_NO_CHANGES_MADE, "Security Group");
            }

            if (isAdd || propertiesChanged.Exists(data => data == Constants.PROPERTY_SG_DISPLAYNAME))
                if(IsSGDisplayNameExist(input.DisplayName))
                    return string.Format(Constants.ERROR_VALUE_EXIST_DB, "Display Name");

            if (isAdd || propertiesChanged.Exists(data => data == Constants.PROPERTY_SG_ALIASNAME))
                if (IsSGAliasNameExist(input.AliasName))
                    return string.Format(Constants.ERROR_VALUE_EXIST_DB, "Alias Name");

            return string.Empty;
        }

        private bool IsSGDisplayNameExist(string displayName) => _db.SecurityGroup_MST.Where(data => data.DisplayName == displayName).Any();
        private bool IsSGAliasNameExist(string aliasName) => _db.SecurityGroup_MST.Where(data => data.AliasName == aliasName).Any();
    }
}
