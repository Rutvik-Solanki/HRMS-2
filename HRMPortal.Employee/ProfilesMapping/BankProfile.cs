
using AutoMapper;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Models.BankDetailDto, Entity.BankDetail>().ReverseMap();

        }   
    }
}
