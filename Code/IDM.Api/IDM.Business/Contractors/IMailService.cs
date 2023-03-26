using IDM.Business.Models.DTOs;
using IDM.Infrastructure.DataAccess;

namespace IDM.Business.Contractors
{
    public interface IMailService
    {
        Task InsertMailAdresss_MST(IDMDbContext db, SecurityGroupDTO input);
        Task DeleteMailAddress_MST(IDMDbContext db, Guid sgInternalID);
    }
}