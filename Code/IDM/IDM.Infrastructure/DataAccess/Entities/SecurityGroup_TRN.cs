using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class SecurityGroup_TRN
    {
        //Request Details
        public string RequestID { get; set; }
        public string Number { get; set; }

        //SG Details
        public Guid InternalID { get; set; }
        [Required, MaxLength(30)]
        public string AliasName { get; set; }
        [Required, MaxLength(30)]
        public string DisplayName { get; set; }
        public int Type { get; set; }

        //SG Ownership Details
        public Guid OwnerInternalID { get; set; }
        public Guid Admin1InternalID { get; set; }
        public Guid Admin2InternalID { get; set; }
        public Guid Admin3InternalID { get; set; }

        //Common Details
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
