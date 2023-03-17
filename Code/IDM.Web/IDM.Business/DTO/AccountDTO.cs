using IDM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Business.DTO
{
    public class AccountDTO
    {
        #region Personal Details
        public Guid InternalID { get; set; }
        public string AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string ProvincialAddress { get; set; }
        #endregion

        #region Employement Details
        public Guid Department_InternalID { get; set; }
        public string DepartmentName { get; set; }

        public Guid Company_InternalID { get; set; }
        public string CompanyName { get; set; }

        public Guid Manager_InternalID { get; set; }
        public string ManagerName { get; set; }

        public string EmployeeType { get; set; }
        public string EmployeeStatus { get; set; }
        #endregion

        #region Common Details
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion

        #region Functions
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return Constants.STRING_NA;

                return string.Format(Constants.FORMAT_FULL_NAME, LastName, FirstName);
            }
        }
        #endregion
    }
}
