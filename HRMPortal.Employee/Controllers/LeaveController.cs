using AutoMapper;
using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/employee/{employeeId}/leave")]
    public class LeaveController:ControllerBase
    {
        private readonly ILeaveProcess _leaveProcess;

        public LeaveController(ILeaveProcess leaveProcess)
        {
            _leaveProcess = leaveProcess ?? throw new ArgumentNullException(nameof(leaveProcess));            
           
        }


        
        [HttpPost]
        public  async Task<IActionResult> AddLeave(LeaveAddModel leaveRequetsModel,int employeeId)
        {
            var LeaveAdded =await  _leaveProcess.AddLeaveProcess(leaveRequetsModel, employeeId);
            if(LeaveAdded!=null)
            {
                return Ok(LeaveAdded);
            }
            return BadRequest();
        }


        [HttpPut("{leaveId}")]
        public async Task<IActionResult> UpdateLeave(LeaveUpdateModel updateLeaveModel, int leaveId, int employeeId)
        {
                var IsUpdated = await _leaveProcess.UpdateLeaveProcess(updateLeaveModel, leaveId, employeeId);
                if (IsUpdated != null)
                {
                    return Ok(IsUpdated);
                }           
                return BadRequest();
        }

        [HttpGet("{leaveId}")]
        public async Task<IActionResult> GetSingleLeaveHistory(int leaveId,int employeeId)
        {
            if (leaveId != null)
            {
                return  Ok(await _leaveProcess.GetSingleLeaveProcess(leaveId, employeeId));                
            }
            return NotFound();
        }
  
        [HttpGet("allhistory")]
        public async Task<IActionResult> GetLeaveHistory(int employeeId)
        {
            if (employeeId != null)
            {
               return Ok(await _leaveProcess.GetLeaveHistoryProcess(employeeId));
                
            }
            return NotFound();
        }

        [HttpDelete("{leaveId}")]
        public async Task<IActionResult> DeleteLeaveById(int leaveId,int employeeId)
        {
             var deletedLeave=await _leaveProcess.DeleteLeaveProcess(leaveId, employeeId);
            if (deletedLeave)
            {
                return Ok();
            }
            return NotFound();
            
        }

     /*   [HttpPatch("PartiallyUpdateLeave")]
        public async Task<ActionResult<LeaveModel>> PartiallyUpdateleave(int leaveId,int employeeId, JsonPatchDocument<LeaveUpdateModel> leaveUpdateModel)
        {
            var ExisteLeave = await _leaveProcess.GetSingleLeaveProcess(leaveId,employeeId);
            if(ExisteLeave==null)
            {
                return NotFound();               
            }
            var leaveToPatch = _mapper.Map<LeaveUpdateModel>(ExisteLeave);
            //remaining to add Model State
            leaveUpdateModel.ApplyTo(leaveToPatch,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(leaveToPatch))
            {
                return BadRequest(ModelState);
            }
            var patchedLeave=_mapper.Map(leaveToPatch, ExisteLeave);

            
            return Ok(_mapper.Map<LeaveModel>(await _leaveProcess.UpdateLeaveProcess(patchedLeave)));
        }*/
        



    }
}
