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
    public class EmailService : IEmailService
    {
        public IEnumerable<EmailAddress_MST> GetMailAddressByRelationID(IDMDbContext db, Guid relationID)
        {
            return db.EmailAddress_MST.Where(data => data.RelationID == relationID);
        }

        public async Task InsertMailAdresss_MST(IDMDbContext db, SecurityGroupDTO input)
        {
            //Get email addresses 
            var emails = Utility.ParseEmailAddresses(input);
            await db.EmailAddress_MST.AddRangeAsync(emails);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_MAILS_INSERT);
        }

        public async Task DeleteEmailAddress_MST(IDMDbContext db, Guid sgInternalID)
        {
            var mailList = await db.EmailAddress_MST.Where(data => data.RelationID == sgInternalID).ToListAsync();

            if (mailList == null || mailList.Count == 0)
                return;

            db.EmailAddress_MST.RemoveRange(mailList);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_MAILS_DELETE);
        }
    }
}
