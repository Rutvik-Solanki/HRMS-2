using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository.Interface;

namespace HRMPortal.Employee.Engine.@class
{
    public class LeaveBalanceEngine : ILeaveBalanceEngine
    {
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly IMapper _mapper;

        public LeaveBalanceEngine(ILeaveBalanceRepository leaveBalanceRepository ,IMapper mapper)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
            _mapper = mapper;
        }

        async Task<LeaveBalance> ILeaveBalanceEngine.GetLeaveBalanceById(int employeeId, int leaveBalanceId)
        {
            var result = await _leaveBalanceRepository.GetLeaveBalanceById(employeeId, leaveBalanceId);
            if (result == null)
            {
                throw new Exception($"LeaveBalance {leaveBalanceId} was not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance(int employeeId)
        {
            var result = await _leaveBalanceRepository.ListOfLeaveBalance(employeeId);
            if (result.Count() <= 0)
            {
                throw new Exception($"employeeId {employeeId} was not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<LeaveBalance> AddLeaveBalance(int employeeId, LeaveBalance leaveBalance)
        {
            if (leaveBalance != null)
            {
                return await _leaveBalanceRepository.AddLeaveBalance(employeeId, leaveBalance);
            }
            else
            {
                throw new Exception("Data not added");
            }
        }

        public async Task<LeaveBalance> UpdateLeaveBalance(LeaveBalance leaveBalance)
        {
            if (leaveBalance != null)
            {
                return await _leaveBalanceRepository.UpdateLeaveBalance(leaveBalance);
            }
            else
            {
                throw new Exception("Data not updated");
            }
        }

        public async Task DeleteLeaveBalance(LeaveBalance leaveBalance)
        {
            if (leaveBalance != null)
            {
                await _leaveBalanceRepository.DeleteLeaveBalance(leaveBalance);
            }
            else
            {
                throw new Exception("Data not deleted");
            }
        }
    }
}
