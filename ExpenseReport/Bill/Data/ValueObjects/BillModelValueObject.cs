using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Bill.Model.Enum;

namespace Bill.Data.ValueObjects
{
    public class BillModelValueObject
    {
        public int UserId { get; set; }
        public int IdBill { get; set; }
        public EBillType Type { get; set; }
        public int IdBillInfo { get { return IdBill; } }
        public EBillStatus Status { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool ShowInstallments { get; set; }
        public int Installments { get; set; }

    }
}
