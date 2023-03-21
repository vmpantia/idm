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
        public SecurityGroupService(IDMDbContext db)
        {
            _db = db;
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
                    var input = Utility.ParseSecurityGroup(request.inputSG);
                    switch (request.FunctionID)
                    {
                        case Constants.FUNCTION_ID_ADD_INTERNAL_SG_BY_USER:
                        case Constants.FUNCTION_ID_ADD_EXTERNAL_SG_BY_USER:
                            await InsertSecurityGroup_MST(input);
                            break;
                        case Constants.FUNCTION_ID_EDIT_INTERNAL_SG_BY_USER:
                        case Constants.FUNCTION_ID_EDIT_EXTERNAL_SG_BY_USER:
                            await UpdateSecurityGroup_MST(input);
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

        private async Task InsertSecurityGroup_MST(SecurityGroup_MST input)
        {
            input.InternalID = Guid.NewGuid();
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = null;

            await _db.AddAsync(input);
            var result = await _db.SaveChangesAsync();

            if (result == 0)
                throw new ServiceException(Constants.ERROR_SG_INSERT);
        }

        private async Task UpdateSecurityGroup_MST(SecurityGroup_MST input)
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

            if (result == 0)
                throw new ServiceException(Constants.ERROR_SG_UPDATE);
        }

        
    }
}
