using System.ComponentModel.DataAnnotations;

namespace IDM.Api.Models
{
    public class SecurityGroupDTO
    {
        //SG Details
        public Guid InternalID { get; set; }
        public string AliasName { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }

        //SG Ownership Details
        public Guid OwnerInternalID { get; set; }
        public string OwnerName { get; set; }
        public Guid Admin1InternalID { get; set; }
        public string Admin1Name { get; set; }
        public Guid Admin2InternalID { get; set; }
        public string Admin2Name { get; set; }
        public Guid Admin3InternalID { get; set; }
        public string Admin3Name { get; set; }

        //Common Details
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
