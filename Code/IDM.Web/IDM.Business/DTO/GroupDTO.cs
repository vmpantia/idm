using IDM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Business.DTO
{
    public class GroupDTO
    {
        #region SG Details
        public Guid InternalID { get; set; }
        public string SGAliasName { get; set; }
        public string SGDisplayName { get; set; }
        public string SGClass { get; set; }
        #endregion

        #region Ownership Details
        public Guid OwnerInternalID { get; set; }
        public string OwnerName { get; set; }

        public Guid Admin1InternalID { get; set; }
        public string Admin1Name { get; set; }

        public Guid Admin2InternalID { get; set; }
        public string Admin2Name { get; set; }

        public Guid Admin3InternalID { get; set; }
        public string Admin3Name { get; set; }
        #endregion

        #region Mail Addresses Details 
        public List<string> MailAddressList { get; set; }
        #endregion

        #region Common Details
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
