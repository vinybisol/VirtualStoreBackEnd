using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Data.Tables
{
    public class ProductTable
    {
        public static void TableBuildBranch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("product");
                entity.Property(e => e.Id).HasColumnName("id").HasDefaultValueSql("gen_random_uuid()");
                entity.HasKey(e => e.Id).HasName("Product_primary_key");

                entity.Property(e => e.FullName).HasColumnName("full_name");
                //entity.Property(e => e.Name).HasColumnName("name");
                //entity.Property(e => e.Price).HasColumnName("price");
                //entity.Property(e => e.MarketPrice).HasColumnName("market_price");
                //entity.Property(e => e.TagId).HasColumnName("tag_id");
                //entity.Property(e => e.Obs).HasColumnName("obs");
                //entity.Property(e => e.MarketObs).HasColumnName("market_obs");
                
                //entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
                //entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasDefaultValueSql("now()");
            });

        }

    }
}
