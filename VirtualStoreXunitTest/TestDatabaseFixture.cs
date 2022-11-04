using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStoreBackEnd.Data;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreXunitTest
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.AddRange(
                        new ProductModel { Id = Guid.NewGuid(), FullName = "ROTEADOR", Name = "Roteador", Price = 1234.12M },
                            new ProductModel { Id = Guid.NewGuid(), FullName = "ROTEADOR", Name = "roteador", Price = 123.1234M });
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public SQLServerContext CreateContext()
            => new SQLServerContext(
                new DbContextOptionsBuilder<SQLServerContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}

