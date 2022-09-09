using Bill.Data.ValueObjects;
using Bill.Model;
using Bill.Repository.Interface;
using Bill.Services;

namespace Bill.Services.Implementations
{
    public class BillServiceImplamentation : IBillService
    {
        private readonly IBillRepository _billRepository;

        public BillServiceImplamentation (IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<BillModelValueObject> Create(BillModelValueObject bill)
        {
            await ValidateBill(bill);
            return await _billRepository.Create(bill);
        }

        public async Task<bool> Delete(int id)
        {
            return await _billRepository.Delete(id);
        }

        public async Task<BillModelValueObject> FindById(int billId)
        {
            return await _billRepository.FindById(billId);
        }

        public async Task<BillModelValueObject> Update(BillModelValueObject bill)
        {
            await ValidateBill(bill);
            return await _billRepository.Update(bill);
        }

        public async Task<List<BillModelValueObject>> FindAll(int userId)
        {
            var bill = await _billRepository.FindAll(userId);
            return bill.ToList();
        }

        private async Task ValidateBill(BillModelValueObject bill)
        {

        }

    }
}
