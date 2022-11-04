using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStoreBackEnd.Model
{
    [Table("product")]
    public class ProductModel
    {
        [Key]        
        public Guid Id { get; set; } = default!;
        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = default!;

        [Column("name")]
        [Required]
        [MaxLength(80)]        
        public string Name { get; set; } = default!;

        [Column("price")]
        [Required]
        [Precision(8,2)]
        [ConcurrencyCheck()]
        public decimal Price { get; set; } = default;

        [Column("market_price")]
        [Precision(8, 2)]
        [ConcurrencyCheck()]
        public decimal MarketPrice { get; set; } = default;

        [Column("tag")]
        [Required]
        [MaxLength(80)]
        public string TagId { get; set; } = default!;

        [Column("obs")]
        [MaxLength(255)]
        public string Obs { get; set; } = default!;

        [Column("market_obs")]
        [MaxLength(255)]
        public string MarketObs { get; set; } = default!;

    }
}
