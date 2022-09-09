using User.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace User.Model
{
    [Table("User")]
    public class UserModel : BaseEntity
    {
        [Key]
        [ForeignKey("IdUser")]
        [Column]
        [ReadOnly(true)]
        public int IdUser { get; set; }

        [Column("name")]
        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Column("email")]
        [Required]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column("phone")]
        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Column("active")]
        [Required]
        [Range(0, 1)]
        public bool Active { get; set; }

        [Column("imageUrl")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [Column("password")]
        [StringLength(45)]
        public string Password { get; set; }

    }
}
