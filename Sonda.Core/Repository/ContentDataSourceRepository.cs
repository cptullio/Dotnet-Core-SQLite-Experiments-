using Sonda.Core.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sonda.Core.Repository
{
    public class ContentDataSourceRepository
    {
        public ContentDataSourceRepository(SondaDbContext context)
        {
            Context = context;
        }

        public SondaDbContext Context { get; }


        public void Insert(ContentDataSource contentDataSource)
        {
            Context.ContentDataSourceDbSet.Add(contentDataSource);
            Context.SaveChanges();
        }

        public void Update(ContentDataSource contentDataSource)
        {
            Context.ContentDataSourceDbSet.Update(contentDataSource);
            Context.SaveChanges();
        }

        public void Delete(ContentDataSource contentDataSource)
        {
            Context.ContentDataSourceDbSet.Remove(contentDataSource);
            Context.SaveChanges();
        }
    }
}
