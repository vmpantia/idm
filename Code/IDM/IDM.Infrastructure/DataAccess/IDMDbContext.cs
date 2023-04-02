using IDM.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDM.Infrastructure.DataAccess
{
    public class IDMDbContext : DbContext
    {
        public IDMDbContext(DbContextOptions<IDMDbContext> options) : base(options) { }

        public virtual DbSet<Request_LST> Request_LST { get; set; }
        public virtual DbSet<SecurityGroup_MST> SecurityGroup_MST { get; set; }
        public virtual DbSet<SecurityGroup_TRN> SecurityGroup_TRN { get; set; }
        public virtual DbSet<EmailAddress_MST> EmailAddress_MST { get; set; }
        public virtual DbSet<EmailAddress_TRN> EmailAddress_TRN { get; set; }
    }
}
