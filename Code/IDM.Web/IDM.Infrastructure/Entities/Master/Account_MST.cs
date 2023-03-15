using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Infrastructure.Entities.Master
{
    [PrimaryKey(nameof(InternalID), nameof(AccountID))]
    public class Account_MST
    {
        //Personal Info
        public Guid InternalID { get; set; }

        [Required, MaxLength(15)]
        public string AccountID { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        public string LastName { get; set; }

        [Required, MaxLength(30)]
        public string MiddleName { get; set; }

        public DateTime Birthdate { get; set; }

        [Required, MaxLength(6)]
        public string Gender { get; set; }

        [Required, MaxLength(15)]
        public string ContactNo { get; set; }

        [Required, MaxLength(100)]
        public string PermanentAddress { get; set; }

        [Required, MaxLength(100)]
        public string PresentAddress { get; set; }

        [Required, MaxLength(100)]
        public string ProvincialAddress { get; set; }

        //Employment Info
        public Guid Department_InternalID { get; set; }
        public Guid Company_InternalID { get; set; }
        public Guid Manager_InternalID { get; set; }

        [Required, MaxLength(1)]
        public string EmployeeType { get; set; }

        [Required, MaxLength(1)]
        public string EmployeeStatus { get; set; }

        //Common Info
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
