using AutoMapper;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Profiles
{
    public class LeaveProfiles:Profile
    {
        public LeaveProfiles()
        {
            CreateMap<LeaveModel, LeaveAddModel>().ReverseMap();
            CreateMap<LeaveAddModel, Entity.Leave>().ReverseMap();
            CreateMap<Entity.Leave, LeaveAddModel>();
            CreateMap<Entity.Leave, LeaveUpdateModel>();
            CreateMap<Entity.Leave, LeaveModel>();
            CreateMap<LeaveModel, Entity.Leave>();
            CreateMap<LeaveUpdateModel, LeaveModel>();
            CreateMap<LeaveUpdateModel, Entity.Leave>();
            CreateMap<EmployeeDto, Entity.EmployeeDetail>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Entity.EmployeeDetail>().ReverseMap();
            CreateMap<EmployeeAddDto, Entity.EmployeeDetail>().ReverseMap();


            
            
        }
    }
}
