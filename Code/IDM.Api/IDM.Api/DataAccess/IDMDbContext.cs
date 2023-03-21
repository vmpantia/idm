using IDM.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDM.Api.DataAccess
{
    public class IDMDbContext : DbContext
    {
        public IDMDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SecurityGroup_MST> SecurityGroup_MST { get; set; }
        public DbSet<SecurityGroup_TRN> SecurityGroup_TRN { get; set; }
    }
}
