using AutoMapper;

using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/emplyoee/{EmplyoeeId}/bankDetail")]
    public class BankDetailsController : ControllerBase
    {
        private readonly IBankProcessor bankProcessor;
        private readonly IMapper mapper;

        public BankDetailsController(IBankProcessor bankProcessor , IMapper mapper)
        {
            this.bankProcessor = bankProcessor;
            this.mapper = mapper;
        }

       [HttpGet]
        public async Task<ActionResult<BankDetailDto>> GetBankDetail(int EmplyoeeId)
        {
            var x =await bankProcessor.GetBankDetails(EmplyoeeId);
            return Ok(x);
        }

        [HttpGet("{BankDetailId}")]
        public async Task<IActionResult> GetBankDetailId(int EmplyoeeId, int BankDetailId)
        {
            var x = await bankProcessor.GetBankDetailById(EmplyoeeId, BankDetailId);
            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> AddBankDetails(int EmplyoeeId, BankDetailDto bankDetailDto)
        {
            
            await bankProcessor.AddBankDetails(EmplyoeeId,mapper.Map<BankDetail>(bankDetailDto));
            return Ok();
        }

        [HttpPut("{BankDetailId}")]
        public async Task<IActionResult> UpdateBankDetails(int EmplyoeeId, int BankDetailId,BankDetailDto bankDetailDto)
        {
           
            await bankProcessor.UpdateBankDetails(EmplyoeeId, BankDetailId, bankDetailDto);
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBankDetail(int EmplyoeeId, int BankDetailId)
        {
           
            await bankProcessor.DeleteBankDetails(EmplyoeeId, BankDetailId);
            return Ok();
        }
        //[HttpPatch("{BankDetailId}")]
        //public async Task<IActionResult> PathchBankDetails(int emplyoeeId, int BankDetailId, JsonPatchDocument<BankDetailDto> bankDetail)
        //{
        //    var x = await bankProcessor.GetBankDetailById(emplyoeeId, BankDetailId);
        //    var y = mapper.Map<BankDetailDto>(x);
        //    bankDetail.ApplyTo(y, ModelState);
        //    await bankProcessor.UpdateBankDetails(mapper.Map(y,x));
        //    return Ok();
        //}


    }
}
