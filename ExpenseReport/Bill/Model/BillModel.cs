using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bill.Model.Enum;

namespace Bill.Model
{
    [Table("Bill")]
    public class BillModel
    {
        [Column("idUser")]
        [Required]
        public int UserId { get; set; }
        
        [Column("idBill")]
        [Required]
        public int IdBill { get; set; }

        [Column("type")]
        [Required]
        public EBillType Type { get; set; }
    }
}
