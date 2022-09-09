using Bill.Data.ValueObjects;

namespace Bill.Services
{
    public interface IBillService
    {
        Task<BillModelValueObject> Create(BillModelValueObject bill);
        Task<BillModelValueObject> Update(BillModelValueObject bill);
        Task<BillModelValueObject> FindById(int billId);
        Task<bool> Delete(int billId);
        Task<List<BillModelValueObject>> FindAll(int userId);
    }
}
