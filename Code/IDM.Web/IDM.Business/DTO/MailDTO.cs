using IDM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Business.DTO
{
    public class MailDTO
    {
        #region Mail Details
        public Guid InternalID { get; set; }
        public string MailAddress { get; set; }
        public string AliasName { get; set; }
        public string MailType { get; set; }
        public string ReceiveType { get; set; }
        public int PrimaryFlag { get; set; }
        #endregion

        #region Common Details
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
