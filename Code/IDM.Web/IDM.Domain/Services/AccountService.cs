using IDM.Business.DTO;
using IDM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Domain.Services
{
    public class AccountService
    {
        private readonly IDMDbContext _db;
        public AccountService(IDMDbContext db)
        {   
            _db = db;
        }

        public async Task<IEnumerable<AccountDTO>> GetAccounts()
        {
            var result = await _db.Account_MST.Select(data =>
                new AccountDTO
                {
                    InternalID = data.InternalID,
                    AccountID = data.AccountID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    MiddleName = data.MiddleName,
                    Birthdate = data.Birthdate,
                    Gender = data.Gender,
                    ContactNo = data.ContactNo,
                    PermanentAddress = data.PermanentAddress,
                    PresentAddress = data.PresentAddress,
                    ProvincialAddress = data.ProvincialAddress,
                    Department_InternalID = data.Department_InternalID,
                    DepartmentName = "",
                    Company_InternalID = data.Company_InternalID,
                    CompanyName = "",
                    Manager_InternalID = data.Manager_InternalID,
                    ManagerName = "",
                    EmployeeType = data.EmployeeType,
                    EmployeeStatus = data.EmployeeStatus,
                    Status = data.Status
                }
            ).ToListAsync();

            return result;
        }
    }
}
