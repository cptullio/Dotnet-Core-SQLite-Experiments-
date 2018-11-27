using Sonda.Core.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sonda.Core.Repository
{
    public class DataSourceRepository
    {
        public DataSourceRepository(SondaDbContext context)
        {
            Context = context;
        }

        public SondaDbContext Context { get; }

        

        public void Insert(DataSource datasource)
        {
            Context.DataSourceDbSet.Add(datasource);
            Context.SaveChanges();
        }

        public void Update(DataSource datasource)
        {
            Context.DataSourceDbSet.Update(datasource);
            Context.SaveChanges();
        }

        public void Delete(DataSource datasource)
        {
            Context.DataSourceDbSet.Remove(datasource);
            Context.SaveChanges();
        }
    }
}
