using AutoMapper;
namespace HRMPortal.Employee.Profiles
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<Models.EducationDetailDto, Entity.EducationDetail>().ReverseMap();
        }
    }
}
