using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Bill.Data.ValueObjects;

namespace Bill.Repository.Interface
{
    public interface IBillRepository
    {
        Task<IEnumerable<BillModelValueObject>> FindAll(int userId);
        Task<BillModelValueObject> FindById(int billId);
        Task<BillModelValueObject> Create(BillModelValueObject billVo);
        Task<BillModelValueObject> Update(BillModelValueObject billVo);
        Task<bool> Delete(int billId);
    }
}
