using AutoMapper;
using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace HRMPortal.Employee.Engine.Class
{
    public class LeaveEngine : ILeaveEngine
    {
        private readonly IleaveRepository _ileaveRepository;
		private readonly HRMPortalEmployeeContext _context;
		private readonly IMapper _mapper;
        private readonly IEmployeeEngine _employeeEngine;

        public LeaveEngine(IleaveRepository ileaveRepository, HRMPortalEmployeeContext context, IMapper mapper,IEmployeeEngine employeeEngine)
        {
            _ileaveRepository = ileaveRepository ?? throw new ArgumentNullException(nameof(ileaveRepository));
			this._context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeEngine = employeeEngine ?? throw new ArgumentNullException(nameof(employeeEngine));
        }

      

        public async Task<IEnumerable<Leave>> GetLeaveHistoryEngine(int employeeId)
        {
            var LeaveData = await _ileaveRepository.GetLeaveHistory(employeeId);
            return LeaveData;
        }

        public async Task<Leave> AddLeaveEngine(Leave leave, int employeeId)
        {
            leave.Guid =  Guid.NewGuid();           
           
            leave.EmployeeDetailId = employeeId;
            return await _ileaveRepository.AddLeave(leave);            
        }

        public async Task<Leave> UpdateLeaveEngine(LeaveUpdateModel leaveUpdate, int leaveId, int employeeId)
        {        
              var ExistLeave = await _ileaveRepository.GetSingleLeave(leaveId, employeeId);
               if(ExistLeave!=null)
                {
                    leaveUpdate.EmployeeDetailId = employeeId;
                    leaveUpdate.RequestId=ExistLeave.Guid;
                    var data=await _ileaveRepository.UpdateLeave(_mapper.Map(leaveUpdate, ExistLeave));
                    //var data=await _ileaveRepository.AddLeave(_mapper.Map(leaveUpdate, ExistLeave));
                    return data;
                }
            return null;
        }

        public async  Task<Leave> GetSingleLeaveEngine(int leaveId, int employeeId)
        {
            var ResponseSingleLeaveEngine=await _ileaveRepository.GetSingleLeave(leaveId,employeeId);
           
            return ResponseSingleLeaveEngine;
        }

        public void  DeleteLeaveEngine(Leave leave)
        {
            _ileaveRepository.DeleteLeave(leave);
        }

    
    }
}
