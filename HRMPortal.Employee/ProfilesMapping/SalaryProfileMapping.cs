using AutoMapper;
using HRMPortal.Employee.Model.SalaryModel;

namespace HRMPortal.Employee.Profiles
{
    public class SalaryProfileMapping : Profile
    {
        public SalaryProfileMapping()
        {
            CreateMap<Model.SalaryModel.SalaryDto, Entity.Salary>().ReverseMap();
            CreateMap<Model.SalaryModel.SalaryAddUpdateDto, Entity.Salary>();          
        }
    }
}
