using IDM.Business;
using IDM.Business.Contractors;
using IDM.Business.Models.DTOs;
using IDM.Common;
using IDM.Domain.Exceptions;
using IDM.Infrastructure.DataAccess;
using IDM.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace IDM.Domain.Services
{
    public class MailService : IMailService
    {
        public IEnumerable<MailAddress_MST> GetMailAddressByRelationID(IDMDbContext db, Guid relationID)
        {
            return db.MailAddress_MST.Where(data => data.RelationID == relationID);
        }

        public async Task InsertMailAdresss_MST(IDMDbContext db, List<MailAddressDTO> mailAddresses, Guid relationID)
        {
            //Get mail Address 
            var mails = Utility.ParseMailAddress(mailAddresses, relationID);
            await db.MailAddress_MST.AddRangeAsync(mails);
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

        public async Task<string> ValidateMailAddresses(IDMDbContext db, List<MailAddressDTO> inputMails, bool isAdd)
        {
            if (inputMails.Count == 0)
                return "Please input atleast 1 mail address.";

            if (!inputMails.Exists(data => data.PrimaryFlag == Constants.MAIL_FLAG_PRIMARY))
                return "Please select primary mail address.";

            foreach(var mail in inputMails)
            {
                if (inputMails.Where(data => data.MailAddress == mail.MailAddress).Count() > 1)
                    return string.Format("{0} has duplicate in your input mail addresses", mail.MailAddress);

                if(IsMailAddressExist(db, mail.MailAddress, mail.RelationID))
                    return string.Format(Constants.ERROR_VALUE_EXIST_DB, mail.MailAddress);
            }

            return string.Empty;
        }
        private bool IsMailAddressExist(IDMDbContext db, string mailAddress, Guid relationID) => db.MailAddress_MST.Where(data => data.MailAddress == mailAddress && 
                                                                                                                                  data.RelationID != relationID).Any();


    }
}
