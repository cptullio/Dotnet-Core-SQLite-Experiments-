using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sonda.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Sonda.Core.Domain;
using System;
using System.Linq;

namespace Sonda.SQLite.Test
{
    [TestClass]
    public class EntityFrameWorkSQLiteTest
    {
        private string connectionString = @"Data Source=d:\newDB.db";
        private Sonda.Core.Repository.SondaDbContext dbContext = null;
        private SondaDbContext getDbContext()
        {
            if (dbContext == null)
            {
                var config = new DbContextOptionsBuilder<SondaDbContext>().UseSqlite(connectionString: connectionString);
                dbContext= new Core.Repository.SondaDbContext(config.Options);
            }
            return dbContext;
        }

        [TestMethod]
        public void InsertTest()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            for (int i = 0; i < 100; i++)
            {
                Core.Domain.Test test = new Core.Domain.Test();
                test.Name = "Teste - " + i;
                
                test.UrlTest = "teste.test.com";
                for (int j = 0; j < 30; j++)
                {
                    Command command = new Command();
                    command.Name = "command " + j + "do test " + i;
                    command.Description  = "command " + j + "do test " + i;
                    command.Target = "target " + j + "do test " + i;
                    command.Value = "Value " + j + "do test " + i;
                    test.CommandList.Add(command);
                }
                
                testRepository.Insert(test);
            }
            
        }

        [TestMethod]
        public void Step1TestUpdateTestInterval()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.Get(10);
            test.IntervalExecution = 10000;
            test.IntervalDataSourceItem = 1000;
            test.ExecutionBegin = DateTime.Now;
            test.ExecutionEnd = DateTime.Now.AddYears(1);
            testRepository.Update(test);
        }

        [TestMethod]
        public void Step2TestAddDataSource()
        {
            
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.Get(11);
            DataSource dataSource = new DataSource();
            dataSource.Name = "User 1";
            ContentDataSource contentDataSource = new ContentDataSource();
            contentDataSource.Chave = "@user";
            contentDataSource.Alvo = "user";
            contentDataSource.Valor = "User 1";
            ContentDataSource contentPassDataSource = new ContentDataSource();
            contentPassDataSource.Chave = "@password";
            contentPassDataSource.Alvo = "password";
            contentPassDataSource.Valor = "pass 1";
            dataSource.ContentDataSourceList.Add(contentDataSource);
            dataSource.ContentDataSourceList.Add(contentPassDataSource);
            test.DataSourceList.Add(dataSource);
            testRepository.Update(test);
        }

        [TestMethod]
        public void Step2TestRemoveDataSource()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            DataSourceRepository dataSourceRepository = new DataSourceRepository(getDbContext());
            var test = testRepository.GetComplete(11);
            
            dataSourceRepository.Delete(test.DataSourceList[0]);
        }

        [TestMethod]
        public void Step2TestUpdateDataSource()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.GetComplete(11);
            DataSourceRepository dataSourceRepository = new DataSourceRepository(getDbContext());
            var dataSource = test.DataSourceList[0];
            dataSource.Name = "UPDATED";
            dataSourceRepository.Update(dataSource);
        }

        [TestMethod]
        public void Step2TestAddContentDataSource()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.GetComplete(11);
            DataSourceRepository dataSourceRepository = new DataSourceRepository(getDbContext());
            var dataSource = test.DataSourceList[0];
            dataSource.ContentDataSourceList.Add(new ContentDataSource() { Chave = "ADDEDD" });
            dataSourceRepository.Update(dataSource);
        }


        [TestMethod]
        public void Step2TestUpdatedContentDataSource()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.GetComplete(11);
            ContentDataSourceRepository contentDataSourceRepository = new ContentDataSourceRepository(getDbContext());
            var dataSource = test.DataSourceList[0];
            var content = dataSource.ContentDataSourceList.Last();
            content.Alvo = "UPDATED!!!";
            contentDataSourceRepository.Update(content);
        }

        [TestMethod]
        public void Step2TesRemoveContentDataSource()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.GetComplete(11);
            ContentDataSourceRepository contentDataSourceRepository = new ContentDataSourceRepository(getDbContext());
            var dataSource = test.DataSourceList[0];
            var content = dataSource.ContentDataSourceList.Last();
            contentDataSourceRepository.Delete(content);
        }


        [TestMethod]
        public void Step3TestUpdateCommand()
        {
            TestRepository testRepository = new TestRepository(getDbContext());
            var test = testRepository.GetComplete(10);
            foreach (var command in test.CommandList)
            {
                command.CanBeIgnored = true;
                command.IsFromDatasource = true;
                command.Value = "@use111r";
                command.IsFromService = true;
                command.UrlService = "http://teste.com.br";
                
            }
            testRepository.Update(test);
        }
    }
}
