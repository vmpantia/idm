using IDM.Business.Validations;
using IDM.Business.Validations.SecurityGroup;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Models.DTOs
{
    public class MailAddressDTO
    {
        //Mail Address Details
        [DisplayName("Mail Address"), MailAddressValidation(true, 50)]
        public string MailAddress { get; set; }
        public Guid RelationID { get; set; } /*Security Group or Account InternalID*/
        public int OwnerType { get; set; }
        public int MailType { get; set; }
        public string MailTypeDescription { get; set; } = string.Empty;
        public int PrimaryFlag { get; set; }
        public string PrimaryFlagDescription { get; set; } = string.Empty;

        //Common Details
        public int Status { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
