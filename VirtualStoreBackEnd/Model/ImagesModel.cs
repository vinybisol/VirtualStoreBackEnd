using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStoreBackEnd.Model
{
    [Table("images")]
    public class ImagesModel
    {
        [Key]
        [Column("key")]
        public Guid Key { get; set; }

        [Column("image")]
        public Byte[]? image { get; set; }

    }
}
