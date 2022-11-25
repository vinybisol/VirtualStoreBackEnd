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
        //[Key]        
        public Guid Id { get; set; } = default!;

        [Column("name")]
        //[Required]
        //[JsonPropertyName("ImageTest")]
        [MaxLength(80)]        
        public string Name { get; set; } = default!;

        [Column("short_name")]
        //[Required]
        [MaxLength(100)]
        public string ShortName { get; set; } = default!;

        [Column("price")]
        //[Required]
        [Precision(8,2)]
        [ConcurrencyCheck()]
        public decimal Price { get; set; } = default;

        [Column("price_market")]
        [Precision(8, 2)]
        [ConcurrencyCheck()]
        public decimal PriceMarket { get; set; } = default;

        //[Column("tag")]
        ////[Required]
        //[MaxLength(80)]
        //public string TagId { get; set; } = default!;

        [Column("note")]
        [MaxLength(255)]
        public string Note { get; set; } = default!;

        //[Column("market_obs")]
        //[MaxLength(255)]
        //public string MarketObs { get; set; } = default!;

        [Column("image_test")]
        public Byte[] ImageTest { get; set; } = default!;

    }
}
