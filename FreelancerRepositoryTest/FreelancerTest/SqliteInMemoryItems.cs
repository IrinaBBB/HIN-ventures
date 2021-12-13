using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.DataAccess.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RepositoryTests.FreelancerTest
{
    public class SqliteInMemoryItems : FreelancerRepositoryTests, IDisposable
    {
        private readonly DbConnection _connection;

        public SqliteInMemoryItems()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();
    }
}
