using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStoreBackEnd.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; } = default!;
        public string FullName { get; set; } = default!;
        //public string Name { get; set; } = default!;
        //public string Price { get; set; } = default!;
        //public string MarketPrice { get; set; } = default!;
        //public string TagId { get; set; } = default!;
        //public string Obs { get; set; } = default!;
        //public string MarketObs { get; set; } = default!;
        //public string CreatedAt { get; set; } = default!;
        //public string UpdateAt { get; set; } = default!;
    }
}
