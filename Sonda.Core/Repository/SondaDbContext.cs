using Microsoft.EntityFrameworkCore;
using Sonda.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonda.Core.Repository
{
    public class SondaDbContext : DbContext
    {

        public SondaDbContext(DbContextOptions<SondaDbContext> options) : base(options)
        {
        }

        public DbSet<Test> TestDbSet { get; set; }
        public DbSet<Command> CommandDbSet { get; set; }
        public DbSet<ContentDataSource> ContentDataSourceDbSet { get; set; }
        public DbSet<DataSource> DataSourceDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Test>().ToTable("Test").HasKey(m => m.Id);

            builder.Entity<Test>().HasMany(x => x.CommandList).WithOne(x => x.Test).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Test>().HasMany(x => x.DataSourceList).WithOne(x => x.Test).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Command>().ToTable("Command").HasKey(m => m.Id);
            
            builder.Entity<ContentDataSource>().ToTable("ContentDataSource").HasKey(m => m.Id);
            
            builder.Entity<DataSource>().ToTable("DataSource").HasKey(m => m.Id);

            builder.Entity<DataSource>().HasMany(x => x.ContentDataSourceList).WithOne(x => x.Datasource).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }

}
