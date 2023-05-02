using AutoMapper;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/employee/{employeeId}/leaveBalance")]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILeaveBalancePrecessor _leaveBalancePrecessor;
        private readonly IMapper _mapper; 

        public LeaveBalanceController(ILeaveBalancePrecessor leaveBalancePrecessor, IMapper mapper)
        {
            _leaveBalancePrecessor = leaveBalancePrecessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("leaveBalanceId")]
        public async Task<IActionResult> GetLeaveBalanceById(int employeeId,int leaveBalanceId)
        {
            return Ok(await _leaveBalancePrecessor.GetLeaveBalanceById(employeeId,leaveBalanceId));            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveBalanceDto>>> ListOfLeaveBalance(int employeeId)
        {
            var leaveBalance = await _leaveBalancePrecessor.ListOfLeaveBalance(employeeId);
            if (leaveBalance == null)
            {
                return NotFound();
            }
            return Ok(leaveBalance);
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveBalance(int employeeId, AddLeaveBalanceDto addLeaveBalanceDto)
        {
            return Ok(await _leaveBalancePrecessor.AddLeaveBalance(employeeId, addLeaveBalanceDto));   
        }

        [HttpPut("{leaveBalanceId}")]
        public async Task<IActionResult> UpdateLeaveBalance(int employeeId, int leaveBalanceId, UpdateLeaveBalanceDto updateLeaveBalanceDto)
        {
           await _leaveBalancePrecessor.UpdateLeaveBalance(employeeId,leaveBalanceId,updateLeaveBalanceDto);
           return Ok();
        }

        [HttpDelete("{leaveBalanceId}")]
        public async Task<ActionResult> DeleteLeaveBalance(int employeeId, int leaveBalanceId)
        {
            
                await _leaveBalancePrecessor.DeleteLeaveBalance(employeeId,leaveBalanceId);
                return Ok($"Id {leaveBalanceId} was Deleted successfully");
        }
    }
}

