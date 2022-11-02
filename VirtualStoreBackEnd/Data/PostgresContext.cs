using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Data.Tables;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext (DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder
     .UseSnakeCaseNamingConvention();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            //Rename Identity tables to lowercase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var currentTableName = modelBuilder.Entity(entity.Name).Metadata.GetDefaultTableName();
                modelBuilder.Entity(entity.Name).ToTable(currentTableName?.ToLower());
            }

            ProductTable.TableBuildBranch(modelBuilder);
        }

        public virtual DbSet<ProductModel> ProductModel { get; set; } = default!;
    }
}
