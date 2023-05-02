using AutoMapper;
using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HRMPortal.Employee.Controllers
{
    [ApiController]
    [Route("api/employee/{employeeId}/salary")]
    public class SalaryController : ControllerBase
    {
        
        private readonly ISalaryProcessor _salaryProcessor;       

        public SalaryController(ISalaryProcessor salaryProcessor)
        {
           
            this._salaryProcessor = salaryProcessor;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetSalary()
        {
            var salaryResult = await _salaryProcessor.GetSalaryAsync();
            return Ok(_mapper.Map<IEnumerable<SalaryDto>>(salaryResult));
        }
*/
        /*[HttpGet("bankdetail/{bankdetailId}/salary")]
        public async Task<IActionResult> GetSalaryByBankDeatilId(int bankdetailId)
        {
            var salaryByBankDetailId = await _salaryProcessor.GetSalaryByBankDetailIdAsysnc(bankdetailId);
            return Ok(_mapper.Map<IEnumerable<SalaryDto>>(salaryByBankDetailId));

        }  */


        [HttpGet]
        public async Task<IActionResult> GetSalaryByEmployeeId(int employeeId)
        {
            var salaryByEmployeeId = await _salaryProcessor.GetSalaryByEmployeeIdAsysnc(employeeId);
            return Ok(salaryByEmployeeId);
        }

        [HttpGet("{salaryId}")]
        public async Task<IActionResult> GetSalaryById(int employeeId, int salaryId)
        {
            var salaryid = await _salaryProcessor.GetSalaryByIdAsysnc(employeeId, salaryId);
            return Ok(salaryid);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(int employeeId, SalaryAddUpdateDto salaryAddUpdateDto)
        {
            await _salaryProcessor.AddSalaryAsync(employeeId, salaryAddUpdateDto);
            return Ok();           
        }

        [HttpPut("{salaryId}")]
        public async Task<IActionResult> UpdateSalaryById(int employeeId, int salaryId, SalaryAddUpdateDto salaryAddUpdateDto)
        {       
            await _salaryProcessor.UpdateSalary(employeeId, salaryId, salaryAddUpdateDto);
            return Ok();
        }

        [HttpDelete("{salaryId}")]
        public async Task<IActionResult> DeleteSalaryById(int employeeId, int salaryId)
        {
            var delete = await _salaryProcessor.DeleteSalaryById(employeeId, salaryId);
            if(delete != null)
            {
                return Ok();
            }
            return NotFound();
            
        }

        /*[HttpPatch("{salaryId}")]
        public async Task<IActionResult> PatchSalaryById(int employeeId, int salaryId,
            JsonPatchDocument<SalaryForUpdateDto> jsonPatchDocument)
        {
            var salaryid = await _salaryProcessor.GetSalaryByIdAsysnc(employeeId, salaryId);
            var salaryToPath = _mapper.Map<SalaryForUpdateDto>(salaryid);
            jsonPatchDocument.ApplyTo(salaryToPath, ModelState);
            var final = _mapper.Map(salaryToPath, salaryid);
            await _salaryProcessor.UpdateSalary(employeeId, _mapper.Map<Salary>(final));
            return Ok();
        }*/




    }
}
