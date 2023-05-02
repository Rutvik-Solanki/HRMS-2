using AutoMapper;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HRMPortal.Employee.Profiles
{
    public class LeaveBalanceProfileMapping:Profile
    {
        public LeaveBalanceProfileMapping()
        {
           
            CreateMap<Model.AddLeaveBalanceDto, Entity.LeaveBalance>().ReverseMap();
            CreateMap<Model.LeaveBalanceDto, Entity.LeaveBalance>().ReverseMap();
            CreateMap<Model.UpdateLeaveBalanceDto, Entity.LeaveBalance>().ReverseMap();
            
        }
    }
}
