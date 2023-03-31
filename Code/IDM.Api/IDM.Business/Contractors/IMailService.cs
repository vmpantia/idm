using IDM.Business.Models.DTOs;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;

namespace IDM.Business.Contractors
{
    public interface IMailService
    {
        IEnumerable<EmailAddress_MST> GetMailAddressByRelationID(IDMDbContext db, Guid relationID);
        Task InsertMailAdresss_MST(IDMDbContext db, List<MailAddressDTO> mailAddresses, Guid relationID);
        Task DeleteEmailAddress_MST(IDMDbContext db, Guid sgInternalID);
        Task<string> ValidateMailAddresses(IDMDbContext db, List<MailAddressDTO> inputMails, bool isAdd);
    }
}