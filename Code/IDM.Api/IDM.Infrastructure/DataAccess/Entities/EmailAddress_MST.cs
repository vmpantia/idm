using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    public class EmailAddress_MST
    {
        //EmailAddress Details
        [Key, MaxLength(50)]
        public string EmailAddress { get; set; }
        public Guid RelationID { get; set; } /*Security Group or Account InternalID*/
        public int OwnerType { get; set; }
        public int EmailType { get; set; }
        public int PrimaryFlag { get; set; }

        //Common Details
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
