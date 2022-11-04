using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStoreBackEnd.Model
{
    [Table("user")]
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Emial { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
