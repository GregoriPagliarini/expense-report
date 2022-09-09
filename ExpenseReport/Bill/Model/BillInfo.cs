using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bill.Model.Enum;

namespace Bill.Model
{
    [Table("bill_info")]
    public class BillInfo
    {
        [Column("idBillInfo")]
        [Required]
        public int IdBillInfo { get; set; }

        [Column("status")]
        [Required]
        public EBillStatus Status { get; set; }

        [Column("description")]
        [Required]
        [StringLength(45)]
        public string Description { get; set; }

        [Column("value")]
        [Required]
        public decimal Value { get; set; }

        [Column("endDate")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Column("firstDate")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("showInstallments")]
        public bool ShowInstallments { get; set; }

        [Column("installments")]
        public int Installments { get; set; }
    }
}
