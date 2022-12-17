using Microsoft.EntityFrameworkCore;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VirtualStoreBackEnd.Model.Input
{
    public class ProductInput
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string ShortName { get; set; } = default!;

        [Precision(8, 2)]
        public decimal Price { get; set; } = default;

        [Precision(8, 2)]
        public decimal PriceMarket { get; set; } = default;

        [MaxLength(255)]
        public string Note { get; set; } = default!;
        public List<IFormFile>? Images { get; set; }

    }
}
