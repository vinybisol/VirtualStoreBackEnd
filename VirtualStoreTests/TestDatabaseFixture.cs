using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VirtualStoreBackEnd.Data;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreTests
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
                        new ProductModel { Id = Guid.NewGuid(), FullName = "ROTEADOR" },
                            new ProductModel { Id = Guid.NewGuid(), FullName = "ROTEADOR" });
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
