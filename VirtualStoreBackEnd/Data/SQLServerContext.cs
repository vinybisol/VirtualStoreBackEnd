using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Data
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext (DbContextOptions<SQLServerContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> ProductModel { get; set; } = default!;

        public DbSet<VirtualStoreBackEnd.Model.UserModel> UserModel { get; set; }
    }
}
