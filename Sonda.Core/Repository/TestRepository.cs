using Sonda.Core.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sonda.Core.Repository
{
    public class TestRepository
    {
        public TestRepository(SondaDbContext context)
        {
            Context = context;
        }

        public SondaDbContext Context { get; }

        public List<Test> Get()
        {
            return Context.TestDbSet.ToList();
        }

        public Test Get(int id)
        {
            return Context.TestDbSet.Where(x=>x.Id == id).FirstOrDefault();
        }

        public Test GetComplete(int id)
        {
            return Context.TestDbSet.Where(x => x.Id == id)
                .Include(x=>x.CommandList)
                .Include(x=>x.DataSourceList)
                .ThenInclude(datasource => datasource.ContentDataSourceList).
                FirstOrDefault();
        }

        public void Insert(Test test)
        {
            Context.TestDbSet.Add(test);
            Context.SaveChanges();
        }

        public void Update(Test test)
        {
            Context.TestDbSet.Update(test);
            Context.SaveChanges();
        }

        public void Delete(Test test)
        {
            Context.TestDbSet.Remove(test);
            Context.SaveChanges();
        }
    }
}
