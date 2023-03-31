using IDM.Business.Models.DTOs;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;

namespace IDM.Business.Contractors
{
    public interface IEmailService
    {
        IEnumerable<EmailAddress_MST> GetMailAddressByRelationID(IDMDbContext db, Guid relationID);
        Task InsertMailAdresss_MST(IDMDbContext db, SecurityGroupDTO input);
        Task DeleteEmailAddress_MST(IDMDbContext db, Guid sgInternalID);
    }
}