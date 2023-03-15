using System;
using System.Collections.Generic;
using IDM.Infrastructure.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace IDM.Infrastructure.Context;

public partial class IDMDbContext : DbContext
{
    public IDMDbContext()
    {
    }

    public IDMDbContext(DbContextOptions<IDMDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account_MST> Account_MST { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=vincent;Initial Catalog=IDM_DB;User ID=admin;Password=admin;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
