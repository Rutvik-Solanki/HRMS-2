using AutoMapper;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.PreviousExprience;

namespace HRMPortal.Employee.ProfilesMapping
{
	public class PreviousExprienceProfileMapping : Profile
	{
		public PreviousExprienceProfileMapping()
		{
			CreateMap<PreviousExprienceGetDto, PreviousExprience>().ReverseMap();
			CreateMap<PreviousExprienceAddDto, PreviousExprience>().ReverseMap();
			CreateMap<PreviousExprienceUpdateDto, PreviousExprience>().ReverseMap();

		}	
		
	}
}
