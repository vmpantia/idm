using IDM.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDM.Infrastructure.DataAccess
{
    public class IDMDbContext : DbContext
    {
        public IDMDbContext(DbContextOptions<IDMDbContext> options) : base(options) { }

        public virtual DbSet<SecurityGroup_MST> SecurityGroup_MST { get; set; }
        public virtual DbSet<SecurityGroup_TRN> SecurityGroup_TRN { get; set; }
    }
}
