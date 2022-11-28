using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStoreBackEnd.Model
{
    [Table("images")]
    public class ImagesModel
    {
        [Key]
        [Column("id")]
        public Guid _id { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("image")]
        public Byte[]? image { get; set; }

        [ForeignKey("ProductForeignKey")]
        public ProductModel ProductModel { get; set; }
    }
}
