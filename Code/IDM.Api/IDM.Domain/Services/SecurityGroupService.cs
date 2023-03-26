using Azure.Core;
using IDM.Business;
using IDM.Business.Contractors;
using IDM.Business.Models.DTOs;
using IDM.Business.Models.Request;
using IDM.Common;
using IDM.Domain.Exceptions;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;
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
            return await _db.SecurityGroup_MST.Where(data => data.Status != Constants.STATUS_INT_DELETION)
                                              .Select(data => Utility.ParseSecurityGroup(data))
                                              .ToListAsync();
        }

        public async Task<IEnumerable<SecurityGroupDTO>> GetSGsByStatusAsync(int status)
        {
            return await _db.SecurityGroup_MST.Where(data => data.Status == status)
                                              .Select(data => Utility.ParseSecurityGroup(data))
                                              .ToListAsync();
        }

        public async Task<SecurityGroupDTO> GetSGByIDAsync(Guid internalID)
        {
            var result = await _db.SecurityGroup_MST.FindAsync(internalID);
            if (result == null)
                throw new ServiceException(Constants.ERROR_SG_NOT_FOUND);

            return Utility.ParseSecurityGroup(result);
        }

        public async Task SaveSGAsync(SaveSecurityGroupRequest request)
        {
            if (request == null)
                throw new ServiceException(Constants.ERROR_SG_SAVE_REQUEST_NULL);

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
                throw new ServiceException(Constants.ERROR_SG_NOT_FOUND);

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

        
    }
}
