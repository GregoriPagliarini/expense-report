using Bill.Data.ValueObjects;
using Bill.Model;
using Bill.Model.Context;
using Bill.Repository.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Bill.Repository.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public BillRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _context = mySQLContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillModelValueObject>> FindAll(int userId)
        {
            List<BillModel> bills = await _context.Bills.Where(bill => bill.UserId == userId).ToListAsync();

            List<BillModelValueObject> billModelVO = new();


            bills.ForEach(async bill =>
            {
                BillInfo billinfo = await _context.BillInfo.Where(billInfo => billInfo.IdBillInfo == bill.IdBill).FirstOrDefaultAsync();

                billModelVO.Add(new BillModelValueObject()
                {
                    IdBill = bill.IdBill,
                    Description = billinfo.Description,
                    EndDate = billinfo.EndDate,
                    Installments = billinfo.Installments,
                    ShowInstallments = billinfo.ShowInstallments,
                    StartDate = billinfo.StartDate,
                    Status = billinfo.Status,
                    Type = bill.Type,
                    UserId = bill.UserId,
                    Value = billinfo.Value 
                });
            });

            return billModelVO;
        }

        public async Task<BillModelValueObject> FindById(int idBill)
        {
            BillModel bill = await _context.Bills.Where(bill => bill.IdBill == idBill).FirstOrDefaultAsync();
            BillInfo billinfo = await _context.BillInfo.Where(billInfo => billInfo.IdBillInfo == bill.IdBill).FirstOrDefaultAsync();
            
            return new BillModelValueObject()
            {
                Type = bill.Type,
                IdBill = bill.IdBill,
                UserId = bill.UserId,
                Description = billinfo.Description,
                EndDate = billinfo.EndDate,
                Installments = billinfo.Installments,
                ShowInstallments = billinfo.ShowInstallments,
                StartDate = billinfo.StartDate,
                Status = billinfo.Status,
                Value = billinfo.Value
            };
        }

        public async Task<BillModelValueObject> Create(BillModelValueObject billModelVO)
        {
            BillModel bill = _mapper.Map<BillModel>(billModelVO);
            BillInfo billInfo = _mapper.Map<BillInfo>(billModelVO);

            try
            {
                _context.Bills.Add(bill);
                await _context.SaveChangesAsync();
                _context.BillInfo.Add(billInfo);
                await _context.SaveChangesAsync();
                return billModelVO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BillModelValueObject> Update(BillModelValueObject billModelVO)
        {
            BillModel bill = _mapper.Map<BillModel>(billModelVO);
            BillInfo billInfo = _mapper.Map<BillInfo>(billModelVO);

            try
            {
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
                _context.BillInfo.Update(billInfo);
                await _context.SaveChangesAsync();
                return billModelVO;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(int billId)
        {
            try
            {
                BillModel bill = await _context.Bills.Where(bill => bill.UserId == billId).FirstOrDefaultAsync();
                if(bill is null) return false;
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
