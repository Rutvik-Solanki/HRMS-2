using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Processor.Class
{
    public class LeaveBalanceProcessor : ILeaveBalancePrecessor
    {
        private readonly ILeaveBalanceEngine _leaveBalanceEngine;
        private readonly IMapper _mapper;

        public LeaveBalanceProcessor(ILeaveBalanceEngine leaveBalanceEngine,IMapper mapper)
        {
            _leaveBalanceEngine = leaveBalanceEngine;
            _mapper = mapper;
        }
        async Task<LeaveBalance> ILeaveBalancePrecessor.GetLeaveBalanceById(int employeeId, int leaveBalanceId)
        {
            return _mapper.Map<LeaveBalance>(await _leaveBalanceEngine.GetLeaveBalanceById(employeeId,leaveBalanceId));   
        }
        public async Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance( int employeeId)
        {
            return _mapper.Map<IEnumerable<LeaveBalance>>(await _leaveBalanceEngine.ListOfLeaveBalance(employeeId));
        }
        public async Task<AddLeaveBalanceDto> AddLeaveBalance(int employeeId, AddLeaveBalanceDto addLeaveBalanceDto)
        {            
            return _mapper.Map<AddLeaveBalanceDto>(await _leaveBalanceEngine.AddLeaveBalance(employeeId,_mapper.Map<LeaveBalance>(addLeaveBalanceDto)));
        }
        public async Task<UpdateLeaveBalanceDto> UpdateLeaveBalance(int employeeId, int leaveBalanceId,UpdateLeaveBalanceDto updateLeaveBalanceDto)
        {
                var update = await _leaveBalanceEngine.GetLeaveBalanceById(employeeId, leaveBalanceId);
                return _mapper.Map<UpdateLeaveBalanceDto>(await _leaveBalanceEngine.UpdateLeaveBalance(_mapper.Map(updateLeaveBalanceDto,update)));
        }
        public async Task DeleteLeaveBalance(int employeeId, int leaveBalanceId)
        {
            var result = await _leaveBalanceEngine.GetLeaveBalanceById(employeeId, leaveBalanceId);
            await _leaveBalanceEngine.DeleteLeaveBalance(_mapper.Map<LeaveBalance>(result));
        }
    }
}
