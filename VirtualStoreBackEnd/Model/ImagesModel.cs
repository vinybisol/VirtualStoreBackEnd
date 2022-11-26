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

        [Column("image1")]
        public Byte[]? images1 { get; set; }

        [Column("image2")]
        public Byte[]? images2 { get; set; }

        [Column("image3")]
        public Byte[]? images3 { get; set; }

        [Column("image4")]
        public Byte[]? images5 { get; set; }

        [Column("image5")]
        public Byte[]? images4 { get; set; }
    }
}
