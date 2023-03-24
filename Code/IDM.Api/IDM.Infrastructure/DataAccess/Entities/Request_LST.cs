using System.ComponentModel.DataAnnotations;

namespace IDM.Infrastructure.DataAccess.Entities
{
    public class Request_LST
    {
        //Request Details
        [Key, MaxLength(15)]
        public string RequestID { get; set; }
        [Required, MaxLength(5)]
        public string FunctionID { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid RequestBy { get; set; }

        //Approver Details
        public DateTime? ApproveDate { get; set; }
        public Guid? ApproveBy { get; set; }

        //Common Details
        [Required, MaxLength(2)]
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
