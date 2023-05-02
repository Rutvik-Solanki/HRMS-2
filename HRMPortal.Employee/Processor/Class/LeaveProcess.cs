using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Processor.Class
{
    public class LeaveProcess : ILeaveProcess
    {
        private readonly ILeaveEngine _leaveEngine;
        private readonly IMapper _mapper;

        public LeaveProcess(ILeaveEngine leaveEngine,IMapper mapper)
        {
            _leaveEngine = leaveEngine ?? throw new ArgumentNullException(nameof(leaveEngine));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<LeaveModel>> GetLeaveHistoryProcess(int employeeId)
        {
            return _mapper.Map<IEnumerable<LeaveModel>>(await _leaveEngine.GetLeaveHistoryEngine(employeeId));
        }

        public async Task<LeaveModel> AddLeaveProcess(LeaveAddModel leave,int employeeId)
        {
             return _mapper.Map<LeaveModel>(await _leaveEngine.AddLeaveEngine(_mapper.Map<Leave>(leave),employeeId));
        }

        public async Task<LeaveModel> UpdateLeaveProcess(LeaveUpdateModel leaveUpdateModel,int leaveId,int employeeId)
        {
            /*  var ExistLeave = await _leaveEngine.GetSingleLeaveEngine(leaveId, employeeId);
              if(ExistLeave != null)
              {
                  return _mapper.Map<LeaveModel>(await _leaveEngine.UpdateLeaveEngine(_mapper.Map(leaveUpdateModel, ExistLeave)));
              }
              return null;*/
            return _mapper.Map<LeaveModel>(await _leaveEngine.UpdateLeaveEngine(leaveUpdateModel, leaveId,employeeId));

        }

        public async Task<LeaveModel> GetSingleLeaveProcess(int leaveId, int employeeId)
        {
            
            return _mapper.Map<LeaveModel>(await _leaveEngine.GetSingleLeaveEngine(leaveId, employeeId));

        }

        public async Task<bool>  DeleteLeaveProcess(int leaveId, int employeeId)
        {
            var ExistLeave = await _leaveEngine.GetSingleLeaveEngine(leaveId, employeeId);
            if (ExistLeave != null)
            {
                _leaveEngine.DeleteLeaveEngine(ExistLeave);
                return true;
            }
            return false;
        }

       
    }
}
