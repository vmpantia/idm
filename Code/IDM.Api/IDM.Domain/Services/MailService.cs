using IDM.Business;
using IDM.Business.Contractors;
using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Domain.Exceptions;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDM.Domain.Services
{
    public class MailService : IMailService
    {
        public IEnumerable<MailAddress_MST> GetMailAddressByRelationID(IDMDbContext db, Guid relationID)
        {
            return db.MailAddress_MST.Where(data => data.RelationID == relationID);
        }

        public async Task InsertMailAdresss_MST(IDMDbContext db, SecurityGroupDTO input)
        {
            var mailList = Utility.ParseMailAddresses(input);
            //Set PrimaryFlag to 0 of PrimaryMailAddress
            mailList.Where(data => data.MailAddress == input.PrimaryMailAddress).First().PrimaryFlag = Constants.MAIL_FLAG_PRIMARY;

            await db.MailAddress_MST.AddRangeAsync(mailList);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_MAILS_INSERT);
        }

        public async Task DeleteMailAddress_MST(IDMDbContext db, Guid sgInternalID)
        {
            var mailList = await db.MailAddress_MST.Where(data => data.RelationID == sgInternalID).ToListAsync();

            if (mailList == null || mailList.Count == 0)
                return;

            db.MailAddress_MST.RemoveRange(mailList);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_MAILS_DELETE);
        }

    }
}
