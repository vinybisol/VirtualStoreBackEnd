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
        public string FullName { get; set; } = default!;
        public string Name { get; set; } = default!;
        [Column("price")]
        [Precision(5,2)]
        public decimal Price { get; set; } = default!;
        public string MarketPrice { get; set; } = default!;
        public string TagId { get; set; } = default!;
        public string Obs { get; set; } = default!;
        public string MarketObs { get; set; } = default!;
        public string CreatedAt { get; set; } = default!;
        public string UpdateAt { get; set; } = default!;
    }
}
