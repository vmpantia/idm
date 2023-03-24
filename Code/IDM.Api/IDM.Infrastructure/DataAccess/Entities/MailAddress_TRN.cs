using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class MailAddress_TRN
    {
        //Request Details
        public string RequestID { get; set; }
        public string Number { get; set; }

        //MailAddress Details
        public string MailAddress { get; set; }
        public Guid RelationID { get; set; } /*Security Group, Account InternalID*/
        public int OwnerType { get; set; }
        public int MailType { get; set; }
        public int PrimaryFlag { get; set; }

        //Common Details
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
