using Microsoft.EntityFrameworkCore;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VirtualStoreBackEnd.Model
{
    [Table("product")]
    public class ProductModel
    {
        [Key]
        [Column("key")]
        public Guid Key { get; set; } = default!;

        [Column("name")]
        [Required]
        [MaxLength(80)]        
        public string Name { get; set; } = default!;

        [Column("short_name")]
        [Required]
        [MaxLength(100)]
        public string ShortName { get; set; } = default!;

        [Column("price")]
        [Precision(8,2)]
        public decimal Price { get; set; } = default;

        [Column("price_market")]
        [Precision(8, 2)]
        public decimal PriceMarket { get; set; } = default;

        [Column("note")]
        [MaxLength(255)]
        public string Note { get; set; } = default!;

        [ForeignKey("product_key")]
        public virtual List<ImagesModel>? Images { get ; set; }

    }
}
