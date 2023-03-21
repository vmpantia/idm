using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    public class SecurityGroup_MST
    {
        //SG Details
        [Key]
        public Guid InternalID { get; set; }
        [Required, MaxLength(30)]
        public string AliasName { get; set; }
        [Required, MaxLength(30)]
        public string DisplayName { get; set; }
        [Required, MaxLength(1)]
        public string Type { get; set; }

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
