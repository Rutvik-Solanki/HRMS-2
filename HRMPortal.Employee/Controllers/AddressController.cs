using HRMPortal.Employee.Model.AddressModel;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Processor.Class;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controllers
{
    [ApiController]
    [Route("api/employee/{employeeId}/address")]
    public class AddressController : ControllerBase
	{
        private readonly IAddressProcessor _addressProcessor;

        public AddressController(IAddressProcessor addressProcessor)
        {
            this._addressProcessor = addressProcessor;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetAddressAsync()
        {
            var address = await _addressProcessor.GetAddressAsync();
            return Ok(address);

        }*/

        [HttpGet]
        public async Task<IActionResult> GetAddressById(int employeeId)
        {
            var result = await _addressProcessor.GetAddressByIdAsync(employeeId);
            return Ok(result);
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetAddressByIds(int employeeId, int addressId)
        {
            var result = await _addressProcessor.GetAddressByIdsAsync(employeeId,addressId);
            return Ok(result);
        }

        [HttpPost("permanentAddress")]
        public async Task<IActionResult> AddPermanentAddress(int employeeId, AddressDto addressDto)
        {
            var permanentAddress = await _addressProcessor.AddPermanentAddress(employeeId, addressDto);
            return Ok(permanentAddress);
        }

        [HttpPost("presentAddress")]
        public async Task<IActionResult> AddPresentAddress(int employeeId, AddressDto addressDto)
        {
            var permanentAddress = await _addressProcessor.AddPresentAddress(employeeId, addressDto);
            return Ok(permanentAddress);
        }


        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteSalaryById(int employeeId, int addressId)
        {
            var delete = await _addressProcessor.DeleteAddressById(employeeId, addressId);
            if (delete != null)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddressById(int employeeId, int addressId, AddressDto addressDto)
        {
            await _addressProcessor.UpdateAddress(employeeId,addressId,addressDto);
            return Ok();
        }

    }
}
