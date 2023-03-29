using IDM.Business.Validations;
using IDM.Business.Validations.SecurityGroup;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IDM.Business.Models.DTOs
{
    public class SecurityGroupDTO
    {
        //SG Details
        public Guid InternalID { get; set; }
        [DisplayName("Alias Name"), NameValidation(true, 30)]
        public string AliasName { get; set; }
        [DisplayName("Display Name"), NameValidation(true, 30)]
        public string DisplayName { get; set; }
        public int Type { get; set; }
        public string TypeDescription { get; set; } = string.Empty;

        //SG Ownership Details
        public Guid OwnerInternalID { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public Guid Admin1InternalID { get; set; }
        public string Admin1Name { get; set; } = string.Empty;
        public Guid Admin2InternalID { get; set; }
        public string Admin2Name { get; set; } = string.Empty;
        public Guid Admin3InternalID { get; set; }
        public string Admin3Name { get; set; } = string.Empty;
        
        //SG Mail Address List
        public List<MailAddressDTO> MailAddresses { get; set; }

        //Common Details
        public int Status { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
