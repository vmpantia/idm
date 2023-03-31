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

            if (emails == null || emails.Count == 0)
                return;

            await db.EmailAddress_MST.AddRangeAsync(emails);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_EMAILS_INSERT);
        }

        public async Task DeleteEmailAddress_MST(IDMDbContext db, Guid sgInternalID)
        {
            var emails = await db.EmailAddress_MST.Where(data => data.RelationID == sgInternalID).ToListAsync();

            if (emails == null || emails.Count == 0)
                return;

            db.EmailAddress_MST.RemoveRange(emails);
            var result = await db.SaveChangesAsync();

            if (result <= 0)
                throw new ServiceException(Constants.ERROR_EMAILS_DELETE);
        }
    }
}
