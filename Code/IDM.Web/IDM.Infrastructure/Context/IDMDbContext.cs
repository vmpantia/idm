using IDM.Infrastructure.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace IDM.Infrastructure.Context
{
    public class IDMDbContext : DbContext
    {
        public IDMDbContext() : base() { }
        public IDMDbContext(DbContextOptions<IDMDbContext> options) : base(options) { }
        public virtual DbSet<Account_MST> Users { get; set; }
    }
}
