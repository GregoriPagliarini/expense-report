using Auth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Model
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column("UserId")]
        [Required]
        [Range(1, 10000000)]
        public int UserId { get; set; }

        [Column("UserName")]
        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;

        [Column("Password")]
        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Column("Active")]
        [Required]
        [Range(0, 1)]
        public bool Active { get; set; }

        [Column("image-url")]
        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
