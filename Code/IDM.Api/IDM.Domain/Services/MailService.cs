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
        public async Task InsertMailAdresss_MST(IDMDbContext db, SecurityGroupDTO input)
        {
            var mailList = new List<MailAddress_MST>
            {
                Utility.ParseSGMailAddress(input.InternalID, input.IDMMailAddress, 0),
                Utility.ParseSGMailAddress(input.InternalID, input.RegionalMailAddress, 1),
                Utility.ParseSGMailAddress(input.InternalID, input.CompanyMailAddress1, 2),
                Utility.ParseSGMailAddress(input.InternalID, input.CompanyMailAddress2, 3)
            };

            //Set PrimaryFlag to 0 of PrimaryMailAddress
            mailList.Where(data => data.MailAddress == input.PrimaryMailAddrress).First().PrimaryFlag = 0;

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
