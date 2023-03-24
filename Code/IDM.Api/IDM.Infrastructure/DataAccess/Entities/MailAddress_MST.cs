using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    [PrimaryKey(nameof(MailAddress), nameof(RelationID))]
    public class MailAddress_MST
    {
        //MailAddress Details
        [Key, MaxLength(30)]
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
