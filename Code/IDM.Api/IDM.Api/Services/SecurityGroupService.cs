using IDM.Api.Contractors;
using IDM.Api.DataAccess;
using IDM.Api.DataAccess.Entities;
using IDM.Api.Exceptions;
using IDM.Api.Models;
using IDM.Api.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace IDM.Api.Services
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
            //Get all security group stored in SecurityGroup_MST with Status 0 or 1
            return await _db.SecurityGroup_MST.Where(data => data.Status != 2)
                                              .Select(data => ParseSecurityGroup(data))
                                              .ToListAsync();
        }

        public async Task<IEnumerable<SecurityGroupDTO>> GetSGsByStatusAsync(int status)
        {
            return await _db.SecurityGroup_MST.Where(data => data.Status == status)
                                              .Select(data => ParseSecurityGroup(data))
                                              .ToListAsync();
        }

        public async Task<SecurityGroupDTO> GetSGByIDAsync(Guid internalID)
        {
            var result = await _db.SecurityGroup_MST.FindAsync(internalID);
            if (result == null)
                throw new ServiceException("Security Group NOT found in the database.");

            return ParseSecurityGroup(result);
        }

        public async Task SaveSGAsync(SaveSecurityGroupRequest request)
        {
            if (request == null)
                throw new ServiceException("Save security group request cannot be NULL or EMPTY.");

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var input = ParseSecurityGroup(request.inputSG);
                    switch (request.FunctionID)
                    {
                        case "001A01":
                        case "002A01":
                            await InsertSecurityGroup_MST(input);
                            break;
                        case "001C01":
                        case "002C01":
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
                throw new ServiceException("Error in inserting security group in the database.");
        }

        private async Task UpdateSecurityGroup_MST(SecurityGroup_MST input)
        {
            var data = await _db.SecurityGroup_MST.FindAsync(input.InternalID);
            if (data == null)
                throw new ServiceException("Security Group NOT found in the database.");

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
                throw new ServiceException("Error in updating security group in the database.");
        }

        private SecurityGroupDTO ParseSecurityGroup(SecurityGroup_MST data)
        {
            return new SecurityGroupDTO
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName,
                DisplayName = data.DisplayName,
                Type = data.Type,
                OwnerInternalID = data.OwnerInternalID,
                OwnerName = "N/A",
                Admin1InternalID = data.Admin1InternalID,
                Admin1Name = "N/A",
                Admin2InternalID = data.Admin2InternalID,
                Admin2Name = "N/A",
                Admin3InternalID = data.Admin3InternalID,
                Admin3Name = "N/A",
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        private SecurityGroup_MST ParseSecurityGroup(SecurityGroupDTO data)
        {
            return new SecurityGroup_MST
            {
                InternalID = data.InternalID,
                AliasName = data.AliasName,
                DisplayName = data.DisplayName,
                Type = data.Type,
                OwnerInternalID = data.OwnerInternalID,
                Admin1InternalID = data.Admin1InternalID,
                Admin2InternalID = data.Admin2InternalID,
                Admin3InternalID = data.Admin3InternalID,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }
    }
}
