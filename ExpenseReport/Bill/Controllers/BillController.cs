using Bill.Data.ValueObjects;
using Bill.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bill.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BillController : ControllerBase
    {
        IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<BillModelValueObject> Post(BillModelValueObject billModelVO)
        {
            return await _billService.Create(billModelVO);
        }

        [HttpPut]
        public async Task<BillModelValueObject> Put(BillModelValueObject userModelVO)
        {
            return await _billService.Update(userModelVO);
        }

        [HttpGet]
        public async Task<BillModelValueObject> Get(int id)
        {
            return await _billService.FindById(id);
        }

        [HttpGet("GetAll")]
        public async Task<List<BillModelValueObject>> GetAll(int userId)
        {
            return await _billService.FindAll(userId);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _billService.Delete(id);
        }


    }
}