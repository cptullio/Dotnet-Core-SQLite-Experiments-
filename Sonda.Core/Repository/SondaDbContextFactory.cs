using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonda.Core.Repository
{
    public class SondaDbContextFactory : IDesignTimeDbContextFactory<SondaDbContext>
    {
        public SondaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SondaDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=d:\newDb.db");

            return new SondaDbContext(optionsBuilder.Options);
        }
    }
}
